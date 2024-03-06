using System;
using System.Data;
using UserTaskApp.Models;
using Dapper;

namespace UserTaskApp.Data
{
    public class UserTaskRepository : IUserTaskRepository
    {
        private readonly IDbConnection _conn;

        // Constructor to initialize the repository with a database connection
        public UserTaskRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        // Method to retrieve a user task by its ID from the database
        public UserTask GetUserTask(int id)
        {
            return _conn.QuerySingle<UserTask>("SELECT * FROM Task WHERE id = @id", new { id });
        }

        // Method to retrieve all user tasks from the database
        public IEnumerable<UserTask> GetAllUserTasks()
        {
            return _conn.Query<UserTask>("SELECT * FROM Task");
        }

        // Method to insert a new user task into the database
        public void InsertUserTask(UserTask userTaskToInsert)
        {
            _conn.Execute("INSERT INTO Task (Title, Description, Status, CreatedBy, AssignedTo, DueDt) VALUES (@title, @description, @status, @createdBy, @assignedTo, @dueDt)",
                new
                {
                    title = userTaskToInsert.Title,
                    description = userTaskToInsert.Description,
                    status = userTaskToInsert.Status,
                    createdBy = userTaskToInsert.CreatedBy,
                    assignedTo = userTaskToInsert.AssignedTo,
                    dueDt = userTaskToInsert.DueDt
                });
        }

        // Method to update an existing user task in the database
        public void UpdateUserTask(UserTask userTask)
        {
            _conn.Execute("UPDATE Task SET Title=@title, Description=@description, Status=@status, createdBy=@createdBy, assignedTo=@assignedTo, dueDt=@dueDt WHERE id=@id",
                new
                {
                    id = userTask.Id,
                    title = userTask.Title,
                    description = userTask.Description,
                    status = userTask.Status,
                    createdBy = userTask.CreatedBy,
                    assignedTo = userTask.AssignedTo,
                    dueDt = userTask.DueDt
                });
        }

        // Method to delete a user task from the database
        public void DeleteUserTask(UserTask userTask)
        {
            _conn.Execute("DELETE FROM Task WHERE Id=@id", new { id = userTask.Id });
        }

        // Method to get all completed tasks
        public IEnumerable<UserTask> GetAllCompletedTasks()
        {
            return _conn.Query<UserTask>("SELECT * FROM Task WHERE Status = 'Completed'");
        }

        // Method to get all in progress tasks
        public IEnumerable<UserTask> GetAllInProgressTasks()
        {
            return _conn.Query<UserTask>("SELECT * FROM Task WHERE Status = 'In Progress'");
        }

        // Method to get all to do tasks
        public IEnumerable<UserTask> GetAllToDoTasks()
        {
            return _conn.Query<UserTask>("SELECT * FROM Task WHERE Status = 'To Do'");
        }
    }
}