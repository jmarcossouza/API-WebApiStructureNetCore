using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiStructureNetCore.Libraries
{
    public class EntitiesLibrary
    {
        /// <summary>
        /// Copia os valores com properties com o mesmo nome de um objeto para o outro.
        /// <para>Este método não irá copiar valores nulos, para copiar valores nulos use <see cref="SetValuesFrom"/>.</para>
        /// <para>Este método diferencia letras maiúsculas e minúsculas nas properties.</para>
        /// </summary>
        /// <param name="source">Objeto fonte onde os valores serão copiados.</param>
        /// <param name="target">Objeto onde serão setados os valores das properties que também existirem no objeto fonte</param>
        /// <param name="AllowEmptyOrWhitespacStrings">Deve ou não copiar strings com espaço em branco ou vazias</param>
        /// <returns>Objeto target com os novos valores.</returns>
        public static TTarget SetBasicValuesFrom<TSource, TTarget>(TSource source, TTarget target, bool AllowEmptyOrWhitespacStrings = false)
        {
            target.GetType().GetProperties().Where(c => c.CanWrite).ToList().ForEach(p =>
            {
                var sourceProperty = source.GetType().GetProperty(p.Name);
                if (sourceProperty == null)
                {
                    return;
                }
                var sourceValue = sourceProperty.GetValue(source);
                if (sourceProperty.CanRead && sourceValue != null)
                {
                    if (sourceProperty.PropertyType == typeof(string) && !AllowEmptyOrWhitespacStrings && string.IsNullOrWhiteSpace((string)sourceValue))
                    {
                        return;
                    }
                    p.SetValue(target, sourceValue);
                }
            });
            return target;
        }

        /// <summary>
        /// Copia os valores com properties com o mesmo nome de um objeto para o outro.
        /// <para>Não irá copiar as properties na <c>ignoreList</c></para>
        /// <para>Este método não irá copiar valores nulos, para copiar valores nulos use <see cref="SetValuesFrom"/>.</para>
        /// <para>Este método diferencia letras maiúsculas e minúsculas nas properties.</para>
        /// 
        /// Copia os valores com properties com o mesmo nome de um objeto para o outro.
        /// </summary>
        /// <param name="source">Objeto fonte onde os valores serão copiados.</param>
        /// <param name="target">Objeto onde serão setados os valores das properties que também existirem no objeto fonte</param>
        /// <param name="AllowEmptyOrWhitespacStrings">Deve ou não copiar strings com espaço em branco ou vazias</param>
        /// <returns>Objeto target com os novos valores.</returns>
        public static TTarget SetBasicValuesFrom<TSource, TTarget>(TSource source, TTarget target, string[] ignoreList, bool AllowEmptyOrWhitespacStrings = false)
        {
            target.GetType().GetProperties().Where(c => c.CanWrite && !ignoreList.Contains(c.Name)).ToList().ForEach(p =>
            {
                var sourceProperty = source.GetType().GetProperty(p.Name);
                if (sourceProperty == null)
                {
                    return;
                }
                var sourceValue = sourceProperty.GetValue(source);
                if (sourceProperty.CanRead && sourceValue != null)
                {
                    if (sourceProperty.PropertyType == typeof(string) && !AllowEmptyOrWhitespacStrings && string.IsNullOrWhiteSpace((string)sourceValue))
                    {
                        return;
                    }
                    p.SetValue(target, sourceValue);
                }
            });
            return target;
        }

        /// <summary>
        /// Copia os valores com properties com o mesmo nome de um objeto para o outro.
        /// <para>Este método irá copiar valores nulos, para não copiar valores nulos use <see cref="SetBasicValuesFrom"/>.</para>
        /// <para>Este método diferencia letras maiúsculas e minúsculas nas properties.</para>
        /// </summary>
        /// <param name="source">Objeto fonte onde os valores serão copiados.</param>
        /// <param name="target">Objeto onde serão setados os valores das properties que também existirem no objeto fonte</param>
        /// <returns>Objeto target com os novos valores.</returns>
        public static TTarget SetValuesFrom<TSource, TTarget>(TSource source, TTarget target)
        {
            target.GetType().GetProperties().Where(c => c.CanWrite).ToList().ForEach(p =>
            {
                var sourceProperty = source.GetType().GetProperty(p.Name);
                if (sourceProperty != null && sourceProperty.CanRead)
                {
                    p.SetValue(target, sourceProperty.GetValue(source));
                }
            });
            return target;
        }

        /// <summary>
        /// Copia os valores com properties com o mesmo nome de um objeto para o outro.
        /// <para>Não irá copiar as properties na <c>ignoreList</c></para>
        /// <para>Este método irá copiar valores nulos, para não copiar valores nulos use <see cref="SetBasicValuesFrom"/>.</para>
        /// <para>Este método diferencia letras maiúsculas e minúsculas nas properties.</para>
        /// </summary>
        /// <param name="source">Objeto fonte onde os valores serão copiados.</param>
        /// <param name="target">Objeto onde serão setados os valores das properties que também existirem no objeto fonte</param>
        /// <param name="ignoreList">Lista com nomes de propriedades a sere ignoradas (não serem copiadas).</param>
        /// <returns>Objeto target com os novos valores.</returns>
        public static TTarget SetValuesFrom<TSource, TTarget>(TSource source, TTarget target, string[] ignoreList)
        {
            target.GetType().GetProperties().Where(c => c.CanWrite && !ignoreList.Contains(c.Name)).ToList().ForEach(p =>
            {
                var sourceProperty = source.GetType().GetProperty(p.Name);
                if (sourceProperty != null && sourceProperty.CanRead)
                {
                    p.SetValue(target, sourceProperty.GetValue(source));
                }
            });
            return target;
        }
    }
}
