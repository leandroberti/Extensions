using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LMB.PropertyExtension
{
    /// <summary>
    /// Extension Methods for Properties.
    /// </summary>
    public static class PropertyExtension
    {
        /// <summary>
        /// Returns the Name within the System.ComponentModel.DataAnnotations.DisplayAttribute from a property.
        /// </summary>
        /// <param name="entity">The class that contains the property from which the Name will be recovered.</param>
        /// <param name="propertyName">The name of the property from which the Name will be recovered.</param>
        /// <returns>
        /// The Name within the System.ComponentModel.DataAnnotations.DisplayAttribute if exists or the value informed
        /// in the <paramref name="propertyName"/> param if not.
        /// </returns>
        public static string GetDisplayAttributeValue(this object entity, string propertyName)
        {
            var property = entity.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return propertyName;
            }

            try
            {
                var attribute = property.GetCustomAttributes(typeof(DisplayAttribute), false)
                    .Cast<DisplayAttribute>().Single();

                return attribute != null ? attribute.Name : propertyName;
            }
            catch (Exception)
            {
                return propertyName;
            }
        }

        /// <summary>
        /// Returns the DisplayName within the System.ComponentModel.DisplayNameAttribute from a property.
        /// </summary>
        /// <param name="entity">The class that contains the property from which the DisplayName will be recovered.</param>
        /// <param name="propertyName">The name of the property from which the DisplayName will be recovered.</param>
        /// <returns>
        /// The Name within the System.ComponentModel.DisplayNameAttribute if exists or the value informed
        /// in the <paramref name="propertyName"/> param if not.
        /// </returns>
        public static string GetDisplayNameAttributeValue(this object entity, string propertyName)
        {
            var property = entity.GetType().GetProperty(propertyName);

            if (property == null)
            {
                return propertyName;
            }

            try
            {
                var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), false)
                    .Cast<DisplayNameAttribute>().Single();

                return attribute != null ? attribute.DisplayName : propertyName;
            }
            catch (Exception)
            {
                return propertyName;
            }
        }

        /// <summary>
        /// Returns the Name within the System.ComponentModel.DataAnnotations.DisplayAttribute from a property.
        /// </summary>
        /// <param name="value">The <see cref="System.Enum"/> that contains the property from which the Name will be recovered.</param>
        /// <returns>
        /// The Name within the System.ComponentModel.DataAnnotations.DisplayAttribute if exists or the value informed
        /// in the <paramref name="value"/> param if not.
        /// </returns>
        public static string GetDisplayAttributeValue(this Enum value)
        {
            var type = value.GetType();
            var info = type.GetField(value.ToString());

            if (info == null)
            {
                return value.ToString();
            }

            try
            {
                var attribute = info.GetCustomAttributes(typeof(DisplayAttribute), false)
                    .Cast<DisplayAttribute>().Single();

                return attribute != null ? attribute.Name : value.ToString();
            }
            catch (Exception)
            {
                return value.ToString();
            }
        }
    }
}
