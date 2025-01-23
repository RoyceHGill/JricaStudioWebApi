
using System.Reflection;

namespace JricaStudioWebAPI.Models.Extentions
{
    static public class DtoDateTimeSanitization
    {
        public static T ConvertDateTimesToUtcTime<T>( this T obj ) where T : new()
        {
            T newObj = new T();

            Type dtoType = typeof( T );
            PropertyInfo[] properties = dtoType.GetProperties();

            foreach ( PropertyInfo propertyInfo in properties )
            {
                Type propType = propertyInfo.PropertyType;

                if ( propType == typeof( DateTime ) || propType == typeof( DateTime? ) )
                {
                    DateTime? localTime = default;

                    try
                    {
                        if ( obj != null )
                        {
                            var dateTimeProperty = propertyInfo.GetValue( obj );
                            if ( dateTimeProperty != null )
                            {
                                localTime = ( DateTime ) dateTimeProperty;
                            }
                        }
                    }
                    catch ( NullReferenceException e )
                    {
                        continue;
                    }


                    if ( localTime != default && localTime.HasValue )
                    {
                        DateTime timeValue = localTime.Value;

                        if ( timeValue.Kind == DateTimeKind.Local || timeValue.Kind == DateTimeKind.Unspecified )
                        {
                            DateTime utcTime = timeValue.ToUniversalTime();
                            propertyInfo.SetValue( newObj, utcTime );
                        }
                        else
                        {
                            propertyInfo.SetValue( newObj, timeValue );
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue( newObj, propertyInfo.GetValue( obj ) );
                    }
                }
                else
                {
                    propertyInfo.SetValue( newObj, propertyInfo.GetValue( obj ) );
                }
            }
            return newObj;
        }

        public static T ConvertDateTimesToLocalTimes<T>( this T obj ) where T : new()
        {
            T newObj = new T();

            Type dtoType = typeof( T );
            PropertyInfo[] properties = dtoType.GetProperties();

            foreach ( PropertyInfo propertyInfo in properties )
            {
                Type propType = propertyInfo.PropertyType;

                if ( propType == typeof( DateTime ) || propType == typeof( DateTime? ) )
                {
                    DateTime? UtcTime = default;

                    try
                    {
                        if( obj != null )
                        {
                            var dateTimeProperty = propertyInfo.GetValue( obj );
                            if ( dateTimeProperty != null )
                            {
                                UtcTime = ( DateTime ) dateTimeProperty;
                            }
                        }
                        
                    }
                    catch ( NullReferenceException e )
                    {
                        continue;
                    }

                    if (UtcTime != default && UtcTime.HasValue )
                    {
                        DateTime timeValue = UtcTime.Value;

                        if ( timeValue.Kind == DateTimeKind.Utc || timeValue.Kind == DateTimeKind.Unspecified )
                        {
                            DateTime localTime = timeValue.ToLocalTime();
                            propertyInfo.SetValue( newObj, localTime );
                        }
                        else
                        {
                            propertyInfo.SetValue( newObj, timeValue );
                        }
                    }
                    else
                    {
                        propertyInfo.SetValue( newObj, propertyInfo.GetValue( obj ) );
                    }
                }
                else
                {
                    propertyInfo.SetValue( newObj, propertyInfo.GetValue( obj ) );
                }
            }
            return newObj;
        }

        public static IEnumerable<T> ConvertCollectionsDateTimesToLocalTime<T>( this IEnumerable<T> collectionOfObj ) where T : new()
        {
            var newCollection = new List<T>();

            foreach ( T item in collectionOfObj )
            {
                newCollection.Add( item.ConvertDateTimesToLocalTimes() );

            }

            return newCollection;
        }


    }
}
