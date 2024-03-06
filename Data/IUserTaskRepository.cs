using System;
using UserTaskApp.Models;

namespace UserTaskApp.Data
{
    public interface IUserTaskRepository
    {
        // Method to retrieve a user task by its ID from the repository
        public UserTask GetUserTask(int id);

        // Method to retrieve all user tasks from the repository
        public IEnumerable<UserTask> GetAllUserTasks();

        // Method to insert a new user task into the repository
        public void InsertUserTask(UserTask userTaskToInsert);

        // Method to update an existing user task in the repository
        public void UpdateUserTask(UserTask userTask);

        // Method to delete a user task from the repository
        public void DeleteUserTask(UserTask userTask);

        // Method to get all completed tasks from the repository
        public IEnumerable<UserTask> GetAllCompletedTasks();

        // Method to get all In progress tasks from the repository
        public IEnumerable<UserTask> GetAllInProgressTasks();

        //Method to get all to do tasks from the repository
        public IEnumerable<UserTask> GetAllToDoTasks();
    }
}

