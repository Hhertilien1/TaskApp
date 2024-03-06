function deleteTask(taskId) {
    if (confirm('Are you sure you want to delete this task?')) {
        // Send AJAX request to delete the task
        var xhr = new XMLHttpRequest();
        xhr.open('DELETE', '/UserTask/DeleteUserTask/' + taskId, true);

        xhr.onload = function () {
            if (xhr.status == 200) {
                // Update the UI to reflect the deletion
                var deletedTask = document.getElementById('task_' + taskId);
                if (deletedTask) {
                    deletedTask.parentNode.removeChild(deletedTask);
                }
                // Reload the page to reflect changes
                location.reload();
            } else {
                // Handle errors if needed
                console.error('Error deleting task: ' + xhr.statusText);
            }
        };

        xhr.onerror = function () {
            // Handle errors if needed
            console.error('Error deleting task: ' + xhr.statusText);
        };

        xhr.send();
    }
}
