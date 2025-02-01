using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

// Implemented the Database class to handle the SQLite database operations
internal class Database
{
    private readonly SQLiteAsyncConnection _connection;

    public Database()
    {
        // Get the application's data directory
        var dataDir = FileSystem.AppDataDirectory;
        // Create the full path to the database file
        var databasePath = Path.Combine(dataDir, "ImageCarousel.db");
        // Set up the options for connecting to the database
        var dbOptions = new SQLiteConnectionString(databasePath, true);
        // Create a connection to the database
        _connection = new SQLiteAsyncConnection(dbOptions);
        // Initialize the database (create tables if they don't exist)
        _ = Initialise();
    }

    private async Task Initialise()
    {
        // Create the ImageInfo table if it doesn't exist
        await _connection.CreateTableAsync<ImageInfo>();
    }

    public async Task<List<ImageInfo>> GetImageInfos()
    {
        // Interacts with the database to get all ImageInfo records
        return await _connection.Table<ImageInfo>().ToListAsync();
    }

    public async Task<ImageInfo> GetImageInfo(int id)
    {
        // Interacts with the database to get a single ImageInfo record by id
        var query = _connection.Table<ImageInfo>().Where(t => t.Id == id);
        return await query.FirstOrDefaultAsync();
    }

    public async Task<int> AddImageInfo(ImageInfo item)
    {
        // Interacts with the database to add a new ImageInfo record
        return await _connection.InsertAsync(item);
    }

    public async Task<int> DeleteImageInfo(ImageInfo item)
    {
        // Interacts with the database to delete an ImageInfo record
        return await _connection.DeleteAsync(item);
    }

    public async Task<int> UpdateImageInfo(ImageInfo item)
    {
        return await _connection.UpdateAsync(item);
    }
}
