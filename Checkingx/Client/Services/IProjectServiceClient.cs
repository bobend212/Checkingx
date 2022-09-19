﻿namespace Checkingx.Client.Services
{
    public interface IProjectServiceClient
    {
        List<Project> Projects { get; set; }
        List<Checking> Checkings { get; set; }

        Task GetProjects();

        Task<Project> GetSingleProject(int projectId);

        Task CreateProject(Project project);

        Task UpdateProject(Project project);

        Task DeleteProject(int id);


        ///

        Task CreateCheckingItem(Checking checking);

        Task<Checking> GetSingleCheckingById(int id);

        Task CorrectError(Checking checking);
    }
}