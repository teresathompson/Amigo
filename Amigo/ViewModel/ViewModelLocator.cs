/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Amigo"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Amigo.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<PessoasViewModel>();
            SimpleIoc.Default.Register<MensalidadesViewModel>();
            SimpleIoc.Default.Register<FluxoCaixaViewModel>();
            SimpleIoc.Default.Register<CaixaTransporteViewModel>();
            SimpleIoc.Default.Register<EmprestimoCaixaTransporteViewModel>();
            SimpleIoc.Default.Register<AnimalViewModel>();
            SimpleIoc.Default.Register<UsuarioViewModel>();
            SimpleIoc.Default.Register<LoginViewModel>();
            SimpleIoc.Default.Register<ConfigViewModel>();
            SimpleIoc.Default.Register<InputViewModel>();
            SimpleIoc.Default.Register<AniversariantesViewModel>();
            SimpleIoc.Default.Register<BemMovelViewModel>();
            SimpleIoc.Default.Register<AgendamentoViewModel>();

        }

        private string _currentPessoasVMKey;
        private string _currentFluxoCaixaVMKey;
        private string _currentCaixaTransporteVMKey;
        private string _currentEmprestimoCaixaTransporteVMKey;
        private string _currentMensalidadesVMKey;
        private string _currentAnimalVMKey;
        private string _currentUsuarioVMKey;
        private string _currentLoginVMKey;
        private string _currentConfigVMKey;
        private string _currentInputVMKey;
        private string _currentAniversariantesVMKey;
        private string _currentBemMovelVMKey;
        private string _currentAgendamentoVMKey;

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public AnimalViewModel Animal
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentAnimalVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentAnimalVMKey);
                }
                _currentAnimalVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<AnimalViewModel>(_currentAnimalVMKey);
            }
        }
        public AniversariantesViewModel Aniversariantes
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentAniversariantesVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentAniversariantesVMKey);
                }
                _currentAniversariantesVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<AniversariantesViewModel>(_currentAniversariantesVMKey);
            }
        }
        public ConfigViewModel Config
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentConfigVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentConfigVMKey);
                }
                _currentConfigVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<ConfigViewModel>(_currentConfigVMKey);
            }
        }

        public InputViewModel Input
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentInputVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentInputVMKey);
                }
                _currentInputVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<InputViewModel>(_currentInputVMKey);
            }
        }

        public BemMovelViewModel BemMovel
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentBemMovelVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentBemMovelVMKey);
                }
                _currentBemMovelVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<BemMovelViewModel>(_currentBemMovelVMKey);
            }
        }

        public AgendamentoViewModel Agendamento
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentAgendamentoVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentAgendamentoVMKey);
                }
                _currentAgendamentoVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<AgendamentoViewModel>(_currentAgendamentoVMKey);
            }
        }
        public FluxoCaixaViewModel FluxoCaixa
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentFluxoCaixaVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentFluxoCaixaVMKey);
                }
                _currentFluxoCaixaVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<FluxoCaixaViewModel>(_currentFluxoCaixaVMKey);
            }
        }
        public LoginViewModel Login
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentLoginVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentLoginVMKey);
                }
                _currentLoginVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<LoginViewModel>(_currentLoginVMKey);
            }
        }
        public MensalidadesViewModel Mensalidades
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentMensalidadesVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentMensalidadesVMKey);
                }
                _currentMensalidadesVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<MensalidadesViewModel>(_currentMensalidadesVMKey);
            }
        }
        public PessoasViewModel Pessoas
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentPessoasVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentPessoasVMKey);
                }
                _currentPessoasVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<PessoasViewModel>(_currentPessoasVMKey);
            }
        }
        public CaixaTransporteViewModel CaixaTransporte
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentCaixaTransporteVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentCaixaTransporteVMKey);
                }
                _currentCaixaTransporteVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<CaixaTransporteViewModel>(_currentCaixaTransporteVMKey);
            }
        }
        public EmprestimoCaixaTransporteViewModel EmprestimoCaixaTransporte
        {
            get
            {
                if (!string.IsNullOrEmpty(_currentEmprestimoCaixaTransporteVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentEmprestimoCaixaTransporteVMKey);
                }
                _currentEmprestimoCaixaTransporteVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<EmprestimoCaixaTransporteViewModel>(_currentEmprestimoCaixaTransporteVMKey);
            }
        }
        
        public UsuarioViewModel Usuario
        {
            get
            {

                if (!string.IsNullOrEmpty(_currentUsuarioVMKey))
                {
                    SimpleIoc.Default.Unregister(_currentUsuarioVMKey);
                }
                _currentUsuarioVMKey = Guid.NewGuid().ToString();
                return ServiceLocator.Current.GetInstance<UsuarioViewModel>(_currentUsuarioVMKey);
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}