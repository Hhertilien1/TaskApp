using Microsoft.AspNetCore.Mvc;
using UserTaskApp.Data;
using UserTaskApp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserTaskApp.Controllers
{
    public class UserTaskController : Controller
    {
        private readonly IUserTaskRepository _UserTaskRepo;

        // Constructor to initialize the repository
        public UserTaskController(IUserTaskRepository repo)
        {
            _UserTaskRepo = repo;
        }

        // Action method to retrieve all user tasks and display them in the Index view
        public IActionResult Index()
        {
            var userTask = _UserTaskRepo.GetAllUserTasks();
            return View(userTask);
        }

        // Action method to view a specific user task based on its ID
        public IActionResult ViewUserTask(int id)
        {
            var userTask = _UserTaskRepo.GetUserTask(id);
            return View(userTask);
        }

        // Action method to insert a user task into the database
        [HttpPost]
        public IActionResult InsertUserTaskToDatabase(UserTask userTaskToInsert)
        {
            if (ModelState.IsValid)
            {
                _UserTaskRepo.InsertUserTask(userTaskToInsert);
                return RedirectToAction("Index");
            }
            // If model state is not valid, redisplay the form with validation errors
            return View("InsertUserTask", userTaskToInsert);
        }

        // Action method to display the form for inserting a new user task
        public IActionResult InsertUserTask(UserTask userTaskToInsert)
        {
            return View(userTaskToInsert);
        }

        // Action method to update a user task in the database
        public IActionResult UpdateUserTaskToDatabase(UserTask userTask)
        {
            if (ModelState.IsValid)
            {
                _UserTaskRepo.UpdateUserTask(userTask);
                return RedirectToAction("Index");
            }
            // If model state is not valid, redisplay the form with validation errors
            return View("UpdateUserTask", userTask);
        }

        // Action method to display the form for updating a user task
        public IActionResult UpdateUserTask(int id)
        {
            UserTask userTask = _UserTaskRepo.GetUserTask(id);
            if (userTask == null)
            {
                // If the user task is not found, return a specific view
                return View("UserTaskNotFound");
            }
            return View(userTask);
        }

        // Action method to delete a user task from the database
        public IActionResult DeleteUserTask(UserTask userTask)
        {
            _UserTaskRepo.DeleteUserTask(userTask);
            return RedirectToAction("Index");
        }

        /// Action method to retrieve all in progress user tasks and display them in the Index view
        public IActionResult InProgressUserTask()
        {
            var inProgressUserTask = _UserTaskRepo.GetAllInProgressTasks();
            return View(inProgressUserTask);
        }

        // Action method to retrieve all To Do user tasks and display them in the Index view
        public IActionResult ToDoUserTask()
        {
            var toDoUserTask = _UserTaskRepo.GetAllToDoTasks();
            return View(toDoUserTask);
        }

        // Action method to retrieve all Completed user tasks and display them in the Index view
        public IActionResult CompletedUserTask()
        {
            var completedUserTask = _UserTaskRepo.GetAllCompletedTasks();
            return View(completedUserTask);
        }
    }
}