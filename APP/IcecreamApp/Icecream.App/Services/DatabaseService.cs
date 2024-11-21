using Icecream.App.Data;
using Icecream.App.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Icecream.App.Services;

public class DatabaseService : IAsyncDisposable
{
    private const string DatabaseName = "Icecream.db3";
    private static readonly string _databasePath=Path.Combine(FileSystem.AppDataDirectory, DatabaseName);

    private SQLiteAsyncConnection? _connection;
    private bool disposedValue;

    private SQLiteAsyncConnection Database =>
        _connection??=new SQLiteAsyncConnection(_databasePath, SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);

    private async Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> actionOnDb)
    {
        await Database.CreateTableAsync<CartItemEntity>();
        return await actionOnDb.Invoke();
    }

    public async Task<int> AddCartItem(CartItemEntity entity) =>
        await ExecuteAsync(async () => await Database.InsertAsync(entity));

    public async Task<int> UpdateCartItem(CartItemEntity cartItem) =>
        await ExecuteAsync(async () => await Database.UpdateAsync(cartItem));

    public async Task<int> DeleteCartItem(CartItemEntity entity) =>
        await ExecuteAsync(async () => await Database.DeleteAsync(entity));

    public async Task<CartItemEntity> GetCartItemAsync(int id) =>
        await ExecuteAsync(async () => await Database.GetAsync<CartItemEntity> (id));

    public async Task<List<CartItemEntity>> GetAllCartItemAsync() =>
        await ExecuteAsync(async () => await Database.Table<CartItemEntity>().ToListAsync());

    public async Task<int> ClearCartAsync() =>
        await ExecuteAsync(async() => await Database.DeleteAllAsync<CartItemEntity>());

    public async ValueTask DisposeAsync()
    {
        await _connection?.CloseAsync();
    }
}
