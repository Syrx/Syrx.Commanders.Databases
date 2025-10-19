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
        /// Asynchronously executes a command without parameters and returns a boolean indicating success.
        /// The command executed is automatically resolved based on the calling method name.
        /// </summary>
        /// <typeparam name="TResult">The type parameter (used for command resolution but not for return value).</typeparam>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the command affected one or more rows; otherwise, <c>false</c>.</returns>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during command execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the <paramref name="cancellationToken"/>.</exception>
        public async Task<bool> ExecuteAsync<TResult>(CancellationToken cancellationToken = default,
            [CallerMemberName] string method = null)
        {
            return await ExecuteAsyncCore<TResult>(parameters: null, cancellationToken, method);
        }

        /// <summary>
        /// Asynchronously executes a command with the provided model as parameters and returns a boolean indicating success.
        /// The command executed is automatically resolved based on the calling method name.
        /// </summary>
        /// <typeparam name="TResult">The type of the model used as parameters.</typeparam>
        /// <param name="model">The model instance containing parameters for the command.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains <c>true</c> if the command affected one or more rows; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="model"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the command setting cannot be found for the specified method.</exception>
        /// <exception cref="System.Data.SqlException">Thrown when a database-related error occurs during command execution.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the <paramref name="cancellationToken"/>.</exception>
        public async Task<bool> ExecuteAsync<TResult>(TResult model,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
        {
            Throw<ArgumentNullException>(model != null, nameof(model));
            return await ExecuteAsyncCore<TResult>(parameters: model!, cancellationToken, method);
        }

        /// <summary>
        /// Core ExecuteAsync implementation that handles all database execute operations with transaction management.
        /// This method is the central point for all database execute operations, eliminating code duplication.
        /// </summary>
        private async Task<bool> ExecuteAsyncCore<TResult>(object parameters,
            CancellationToken cancellationToken, string method)
        {
            var setting = GetCommandSetting(method);
            using (var connection = _connector.CreateConnection(setting))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction(setting.IsolationLevel))
                {
                    try
                    {
                        var command = GetCommandDefinition(setting, parameters, transaction, cancellationToken);
                        var result = (await connection.ExecuteAsync(command) > 0);
                        transaction.Commit();
                        return result;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        /// <summary>
        /// Asynchronously executes a user-defined function within a transaction scope and returns the result.
        /// </summary>
        /// <typeparam name="TResult">The return type of the mapping function.</typeparam>
        /// <param name="map">A function to execute within the transaction scope.</param>
        /// <param name="scopeOption">The transaction scope option. Defaults to <see cref="TransactionScopeOption.Suppress"/>.</param>
        /// <param name="asyncFlowOption">The async flow option for the transaction scope. Defaults to <see cref="TransactionScopeAsyncFlowOption.Enabled"/>.</param>
        /// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        /// <param name="method">The name of the calling method. This parameter is automatically populated by the compiler.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the result of executing the <paramref name="map"/> function.</returns>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="map"/> is <c>null</c>.</exception>
        /// <exception cref="OperationCanceledException">Thrown when the operation is canceled via the <paramref name="cancellationToken"/>.</exception>
        /// <remarks>
        /// This method wraps a synchronous function in an async context which may not be optimal for performance.
        /// Consider using truly asynchronous operations when possible.
        /// </remarks>
        public async Task<TResult> ExecuteAsync<TResult>(Func<TResult> map,
            TransactionScopeOption scopeOption = TransactionScopeOption.Suppress,
            TransactionScopeAsyncFlowOption asyncFlowOption = TransactionScopeAsyncFlowOption.Enabled,
            CancellationToken cancellationToken = default, [CallerMemberName] string method = null)
        {
            // i'm honestly not lovin this method. looks like it could cause
            // too many holes and could lead to some seriously, serious
            // nasty, nasty.             
            using (var scope = new TransactionScope(scopeOption, TransactionScopeAsyncFlowOption.Enabled))
            {
                // could also be abused as sync over async.
                // todo: write tests to prove abuse and write about 
                // why it's bad, bad, bad. 
                var result = await Task.FromResult(map());
                scope.Complete();
                return result;
            }
        }
    }
}