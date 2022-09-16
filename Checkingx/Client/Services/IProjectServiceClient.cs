﻿namespace Checkingx.Client.Services
{
    public interface IProjectServiceClient
    {
        List<Project> Projects { get; set; }

        List<CheckItem> CheckingList { get; set; }

        Task GetProjects();

        Task<Project> GetSingleProject(int id);

        Task CreateProject(Project project);

        Task UpdateProject(Project project);

        Task DeleteProject(int id);

        Task GetCheckingList();

        Task<CheckItem> GetSingleCheckItem(int id);

        Task CreateCheckingItem(Checking checking);

        Task<Checking> GetSingleCheckingById(int id);

        Task CorrectError(Checking checking);
    }
}