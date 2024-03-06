using Microsoft.AspNetCore.Mvc;
using System.Data.SQLite;
using System.Diagnostics;
using UserTaskApp.Models;

namespace UserTaskApp.Controllers
{
    public sealed class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly string _sqliteDbPath;

        ///--------------------------------------------------------------------------------
        /// <summary> Constructor. </summary>
        /// <param name="logger"> The logger. </param>
        /// <param name="env">    The environment. </param>
        ///--------------------------------------------------------------------------------
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _sqliteDbPath = $"{env.ContentRootPath}\\App_Data\\UserTaskApp.sqlite";
        }

        ///--------------------------------------------------------------------------------
        /// <summary> (An Action that handles HTTP GET requests) The index action. </summary>
        /// <returns> A response to return to the caller. </returns>
        ///--------------------------------------------------------------------------------
        [HttpGet]
        public IActionResult Index()
        {
            return View("Index");
        }

        ///--------------------------------------------------------------------------------
        /// <summary> The error action. </summary>
        /// <returns> A response to return to the caller. </returns>
        ///--------------------------------------------------------------------------------
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        ///--------------------------------------------------------------------------------
        /// <summary> Create and open a connection to the local SQLite database. </summary>
        /// <returns> The SQLite connection. </returns>
        ///--------------------------------------------------------------------------------
        private SQLiteConnection CreateAndOpenSqliteConnection()
        {
            var sb = new SQLiteConnectionStringBuilder
            {
                DataSource = _sqliteDbPath,
                FailIfMissing = true
            };

            var connection = new SQLiteConnection(sb.ToString());
            try
            {
                return connection.OpenAndReturn();
            }
            catch
            {
                try
                {
                    connection.Dispose();
                }
                catch
                { }

                throw;
            }
        }
    }
}
