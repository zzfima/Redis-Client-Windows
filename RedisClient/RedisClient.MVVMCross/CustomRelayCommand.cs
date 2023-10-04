using System;
using System.Windows.Input;

namespace RedisClient.MVVMCross
{
	public sealed class CustomRelayCommand : ICommand
	{
		private readonly Predicate<object> _canExecute;
		private readonly Action<object> _execute;

		public CustomRelayCommand(Predicate<object> canExecute, Action<object> execute)
		{
			_canExecute = canExecute;
			_execute = execute;
		}

		public event EventHandler? CanExecuteChanged
		{
			add => CommandManager.RequerySuggested += value;
			remove => CommandManager.RequerySuggested -= value;
		}

		public bool CanExecute(object? parameter)
		{
			if (parameter != null)
				return _canExecute(parameter);
			return false;
		}

		public void Execute(object? parameter)
		{
			if (parameter != null)
				_execute(parameter);
		}
	}
}