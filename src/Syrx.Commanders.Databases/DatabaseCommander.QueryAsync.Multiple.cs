//  ============================================================================================================================= 
//  author       : david sexton (@sextondjc | sextondjc.com)
//  date         : 2017.10.15 (17:58)
//  licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
//  =============================================================================================================================

using System.Collections;
using System.Linq;
using System.Reflection;

namespace Syrx.Commanders.Databases
{
    public sealed partial class DatabaseCommander<TRepository> //: ICommander
    {
        /// <summary>
        /// Asynchronously executes a multiple result set query using one type, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the result set of <typeparamref name="T1"/> to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, TResult>(Func<IEnumerable<T1>, IEnumerable<TResult>> map,
             object parameters = null, CancellationToken cancellationToken = default,
             [CallerMemberName] string method = null)
            => await QueryAsync<T1, Ignore, TResult>((t1, _) => map(t1), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using two types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the two result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, Ignore, TResult>((t1, t2, _) => map(t1, t2), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using three types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the three result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, Ignore, TResult>((t1, t2, t3, _) => map(t1, t2, t3), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using four types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the four result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<TResult>> map,
            object parameters = null, CancellationToken cancellationToken = default,
            [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, Ignore, TResult>((t1, t2, t3, t4, _) => map(t1, t2, t3, t4), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using five types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the five result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>,
                IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, Ignore, TResult>((t1, t2, t3, t4, t5, _) => map(t1, t2, t3, t4, t5), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using six types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the six result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, Ignore, TResult>((t1, t2, t3, t4, t5, t6, _) => map(t1, t2, t3, t4, t5, t6), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using seven types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the seven result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, _) => map(t1, t2, t3, t4, t5, t6, t7), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using eight types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the eight result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, _) => map(t1, t2, t3, t4, t5, t6, t7, t8), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using nine types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the nine result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using ten types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the ten result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<TResult>> map,
            object parameters = null, CancellationToken cancellationToken = default,
            [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using eleven types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set from the query.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the eleven result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>,
                IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using twelve types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set from the query.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set from the query.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the twelve result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
            Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>, IEnumerable<T6>,
                IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>, IEnumerable<T11>, IEnumerable<T12>,
                IEnumerable<TResult>> map, object parameters = null,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using thirteen types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set from the query.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set from the query.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set from the query.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the thirteen result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>>
            QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
                Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>,
                    IEnumerable<T6>, IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>,
                    IEnumerable<T11>, IEnumerable<T12>, IEnumerable<T13>, IEnumerable<TResult>> map,
                object parameters = null, CancellationToken cancellationToken = default,
                [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using fourteen types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set from the query.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set from the query.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set from the query.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set from the query.</typeparam>
        /// <typeparam name="T14">The type of objects in the fourteenth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the fourteen result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>>
            QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
                Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>,
                    IEnumerable<T6>, IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>,
                    IEnumerable<T11>, IEnumerable<T12>, IEnumerable<T13>, IEnumerable<T14>, IEnumerable<TResult>> map,
                object parameters = null, CancellationToken cancellationToken = default,
                [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using fifteen types, combining the result sets with a mapping function to produce the final result.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set from the query.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set from the query.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set from the query.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set from the query.</typeparam>
        /// <typeparam name="T14">The type of objects in the fourteenth result set from the query.</typeparam>
        /// <typeparam name="T15">The type of objects in the fifteenth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the fifteen result sets to <typeparamref name="TResult"/>.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        public async Task<IEnumerable<TResult>>
            QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
                Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>,
                    IEnumerable<T6>, IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>,
                    IEnumerable<T11>, IEnumerable<T12>, IEnumerable<T13>, IEnumerable<T14>, IEnumerable<T15>,
                    IEnumerable<TResult>> map, object parameters = null,
                CancellationToken cancellationToken = default,
                [CallerMemberName] string method = null)
            => await QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, Ignore, TResult>((t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15, _) => map(t1, t2, t3, t4, t5, t6, t7, t8, t9, t10, t11, t12, t13, t14, t15), parameters, cancellationToken, method);

        /// <summary>
        /// Asynchronously executes a multiple result set query using up to sixteen types, combining the result sets with a mapping function to produce the final result.
        /// This is the core implementation method that all other async multiple result set query overloads delegate to.
        /// </summary>
        /// <typeparam name="T1">The type of objects in the first result set from the query.</typeparam>
        /// <typeparam name="T2">The type of objects in the second result set from the query.</typeparam>
        /// <typeparam name="T3">The type of objects in the third result set from the query.</typeparam>
        /// <typeparam name="T4">The type of objects in the fourth result set from the query.</typeparam>
        /// <typeparam name="T5">The type of objects in the fifth result set from the query.</typeparam>
        /// <typeparam name="T6">The type of objects in the sixth result set from the query.</typeparam>
        /// <typeparam name="T7">The type of objects in the seventh result set from the query.</typeparam>
        /// <typeparam name="T8">The type of objects in the eighth result set from the query.</typeparam>
        /// <typeparam name="T9">The type of objects in the ninth result set from the query.</typeparam>
        /// <typeparam name="T10">The type of objects in the tenth result set from the query.</typeparam>
        /// <typeparam name="T11">The type of objects in the eleventh result set from the query.</typeparam>
        /// <typeparam name="T12">The type of objects in the twelfth result set from the query.</typeparam>
        /// <typeparam name="T13">The type of objects in the thirteenth result set from the query.</typeparam>
        /// <typeparam name="T14">The type of objects in the fourteenth result set from the query.</typeparam>
        /// <typeparam name="T15">The type of objects in the fifteenth result set from the query.</typeparam>
        /// <typeparam name="T16">The type of objects in the sixteenth result set from the query.</typeparam>
        /// <typeparam name="TResult">The return type after applying the mapping function.</typeparam>
        /// <param name="map">A function that maps the result sets to <typeparamref name="TResult"/>. Unused result sets will receive empty enumerables.</param>
        /// <param name="parameters">The parameters to pass to the command. Can be null if no parameters are required.</param>
        /// <param name="cancellationToken">A cancellation token to observe while waiting for the task to complete.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a sequence of data of type <typeparamref name="TResult"/>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during query execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the cancellation token.</exception>
        /// <exception cref="InvalidCastException">Thrown when a result set cannot be cast to the expected type.</exception>
        /// <remarks>
        /// This method uses Dapper's QueryMultipleAsync functionality to read multiple result sets from a single database query.
        /// It automatically detects the number of actual types by identifying <see cref="Ignore"/> placeholder types.
        /// For type parameters marked as <see cref="Ignore"/>, empty enumerables of the appropriate type are provided to the mapping function.
        /// The method uses reflection to dynamically invoke the generic ReadAsync methods for each result set type.
        /// Each result set is read with buffering enabled (true) to ensure all data is materialized before proceeding to the next result set.
        /// </remarks>
        public async Task<IEnumerable<TResult>> QueryAsync<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
                Func<IEnumerable<T1>, IEnumerable<T2>, IEnumerable<T3>, IEnumerable<T4>, IEnumerable<T5>,
                    IEnumerable<T6>, IEnumerable<T7>, IEnumerable<T8>, IEnumerable<T9>, IEnumerable<T10>,
                    IEnumerable<T11>, IEnumerable<T12>, IEnumerable<T13>, IEnumerable<T14>, IEnumerable<T15>,
                    IEnumerable<T16>, IEnumerable<TResult>> map, object parameters = null,
                CancellationToken cancellationToken = default,
                [CallerMemberName] string method = null)
        {
            var setting = GetCommandSetting(method);
            var command = GetCommandDefinition(setting, parameters, cancellationToken: cancellationToken);
            using (var connection = _connector.CreateConnection(setting))
            {
                var reader = await connection.QueryMultipleAsync(command);
                
                var types = new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8), typeof(T9), typeof(T10), typeof(T11), typeof(T12), typeof(T13), typeof(T14), typeof(T15), typeof(T16) };
                var actualTypeCount = types.TakeWhile(t => t != typeof(Ignore)).Count();
                
                // Read the actual result sets
                var actualResults = new object[16];
                for (int i = 0; i < actualTypeCount; i++)
                {
                    var readMethod = typeof(SqlMapper.GridReader).GetMethods()
                        .Where(m => m.Name == "ReadAsync" && m.IsGenericMethodDefinition && m.GetParameters().Length == 1 && m.GetParameters()[0].ParameterType == typeof(bool))
                        .Single()
                        .MakeGenericMethod(types[i]);
                    var taskResult = (Task)readMethod.Invoke(reader, new object[] { true })!;
                    await taskResult;
                    var resultProperty = taskResult.GetType().GetProperty("Result")!;
                    actualResults[i] = resultProperty.GetValue(taskResult)!;
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
                    (IEnumerable<T16>)actualResults[15]);
            }
        }
    }
}