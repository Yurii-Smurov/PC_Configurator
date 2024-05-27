namespace Configurator.Views
{
    class ViewController
    {
        private IView _currentView;

        public ViewController()
        {
            _currentView = new EnterView(this);
        }

        public void ChangeState(IView view)
        {
            _currentView = view;
        }

        public void ShowCurrentView()
        {
            _currentView.Show();
        }
    }
}
