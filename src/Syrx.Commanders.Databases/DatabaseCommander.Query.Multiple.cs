//  ============================================================================================================================= 
//  author       : david sexton (@sextondjc | sextondjc.com)
//  date         : 2017.10.15 (17:58)
//  licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  =============================================================================================================================
namespace Syrx.Commanders.Databases
{
    public sealed partial class DatabaseCommander<TRepository>
    {
        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first result set into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the first result set into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, TResult>(Func<IEnumerable<T1>, IEnumerable<TResult>> map,
            object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, Ignore, TResult>((t1, _) => map(t1), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first two result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the two result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<TResult>> map, object parameters = null,
            [CallerMemberName] string method = null)
            => Query<T1, T2, Ignore, TResult>((t1, t2, _) => map(t1, t2), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first three result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the three result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<TResult>> map, object parameters = null,
            [CallerMemberName] string method = null)
            => Query<T1, T2, T3, Ignore, TResult>((t1, t2, t3, _) => map(t1, t2, t3), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first four result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the four result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<TResult>> map,
            object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, Ignore, TResult>((t1, t2, t3, t4, _) => map(t1, t2, t3, t4), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first five result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the five result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>,
                IEnumerable<TResult>> map, object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, Ignore, TResult>((t1, t2, t3, t4, t5, _) => map(t1, t2, t3, t4, t5), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first six result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the six result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<TResult>> map, object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, Ignore, TResult>((t1, t2, t3, t4, t5, t6, _) => map(t1, t2, t3, t4, t5, t6), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first seven result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the seven result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<TResult>> map, object parameters = null,
            [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, _) => map(t1, t2, t3, t4, t5, t6, t7), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first eight result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the eight result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<TResult>> map, object parameters = null,
            [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, _) => map(t1, t2, t3, t4, t5, t6, t7, t8), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first nine result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the nine result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<TResult>> map, object parameters = null,
            [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first ten result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the ten result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<TResult>> map,
            object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first eleven result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the eleven result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>,
                IEnumerable<TResult>> map, object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first twelve result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the twelve result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>, IEnumerable<T12>,
                IEnumerable<TResult>> map, object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first thirteen result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the thirteen result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>, IEnumerable<T12>,
                IEnumerable<T13>, IEnumerable<TResult>> map, object parameters = null,
            [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first fourteen result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set.</typeparam>
        /// <typeparam name="T14">The type of objects in the fourteenth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the fourteen result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>, IEnumerable<T12>,
                IEnumerable<T13>, IEnumerable<T14>, IEnumerable<TResult>> map, object parameters = null,
            [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform the first fifteen result sets into the desired output.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set.</typeparam>
        /// <typeparam name="T14">The type of objects in the fourteenth result set.</typeparam>
        /// <typeparam name="T15">The type of objects in the fifteenth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the fifteen result sets into the desired output.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        public IEnumerable<TResult> Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>, IEnumerable<T12>,
                IEnumerable<T13>, IEnumerable<T14>, IEnumerable<T15>, IEnumerable<TResult>> map,
            object parameters = null, [CallerMemberName] string method = null)
            => Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15), parameters, method);

        /// <summary>
        /// Executes a query that returns multiple result sets and applies a mapping function to transform up to sixteen result sets into the desired output.
        /// This is the core implementation method that all other multiple result set query overloads delegate to.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set.</typeparam>
        /// <typeparam name="T14">The type of objects in the fourteenth result set.</typeparam>
        /// <typeparam name="T15">The type of objects in the fifteenth result set.</typeparam>
        /// <typeparam name="T16">The type of objects in the sixteenth result set.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function to transform the result sets into the desired output. Unused result sets will be empty enumerables.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <remarks>
        /// This method uses Dapper's QueryMultiple functionality to execute a single command that returns multiple result sets.
        /// It automatically detects the number of actual result sets by identifying <see cref="Ignore"/> placeholder types.
        /// For type parameters marked as <see cref="Ignore"/>, empty enumerables of the appropriate type are provided to the mapping function.
        /// The method uses reflection to dynamically read the correct number of result sets and create empty enumerables for unused types.
        /// </remarks>
        public IEnumerable<TResult>
            Query<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
                Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>,
                    IEnumerable<T6>, IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>,
                    IEnumerable<T11>, IEnumerable<T12>, IEnumerable<T13>, IEnumerable<T14>, IEnumerable<T15>,
                    IEnumerable<T16>, IEnumerable<TResult>> map, object parameters = null,
                [CallerMemberName] string method = null)
        {
            var setting = GetCommandSetting(method);
            var command = GetCommandDefinition(setting, parameters);
            using (var connection = _connector.CreateConnection(setting))
            {
                var reader = connection.QueryMultiple(command);
                
                var types = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16) };
                var actualTypeCount = types.TakeWhile(t => t != typeof(Ignore)).Count();
                
                // Read the actual result sets
                var actualResults = new object[16];
                for (int i = 0; i < actualTypeCount; i++)
                {
                    var readMethod = typeof(SqlMapper.GridReader).GetMethods()
                        .Where(m => m.Name == "Read" && m.IsGenericMethodDefinition && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(bool))
                        .Single()
                        .MakeGenericMethod(types[i]);
                    actualResults[i] = readMethod.Invoke(reader, new object[] { true })!;
                }
                
                // Create properly typed empty enumerables for ignored types
                for (int i = actualTypeCount; i < 16; i++)
                {
                    var emptyMethod = typeof(Enumerable).GetMethod("Empty")!.MakeGenericMethod(types[i]);
                    actualResults[i] = emptyMethod.Invoke(null, null)!;
                }
                
                return map(
                    (IEnumerable<T1>)actualResults[0], 
                    (IEnumerable<T2>)actualResults[1], 
                    (IEnumerable<T3>)actualResults[2], 
                    (IEnumerable<T4>)actualResults[3], 
                    (IEnumerable<T5>)actualResults[4], 
                    (IEnumerable<T6>)actualResults[5], 
                    (IEnumerable<T7>)actualResults[6], 
                    (IEnumerable<T8>)actualResults[7], 
                    (IEnumerable<T9>)actualResults[8], 
                    (IEnumerable<T10>)actualResults[9], 
                    (IEnumerable<T11>)actualResults[10], 
                    (IEnumerable<T12>)actualResults[11], 
                    (IEnumerable<T13>)actualResults[12], 
                    (IEnumerable<T14>)actualResults[13], 
                    (IEnumerable<T15>)actualResults[14], 
                    (IEnumerable<T16>)actualResults[15]
                );
            }
        }
    }
}