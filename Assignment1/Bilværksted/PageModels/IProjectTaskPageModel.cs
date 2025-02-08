using CommunityToolkit.Mvvm.Input;
using Bilværksted.Models;

namespace Bilværksted.PageModels;

public interface IProjectTaskPageModel
{
	IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
	bool IsBusy { get; }
}