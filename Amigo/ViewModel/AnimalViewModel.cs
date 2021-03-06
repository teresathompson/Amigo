﻿using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Amigo.ViewModel
{
    public class AnimalViewModel:ViewModelBase
    {
        #region Commands
        public RelayCommand SelecaoFotoCommand
        {
            get;
            private set;
        }
        public RelayCommand SalvarCommand
        {
            get;
            private set;
        }

        public RelayCommand NovoItemCommand
        {
            get;
            private set;
        }

        public RelayCommand PesquisaCommand
        {
            get;
            private set;
        }
        public RelayCommand ExcluiCommand
        {
            get;
            private set;
        }
        public RelayCommand NovaVacinaCommand
        {
            get;
            private set;
        }
        public RelayCommand ExcluiVacinaCommand
        {
            get;
            private set;
        }
        public RelayCommand NovaVermifugoCommand
        {
            get;
            private set;
        }
        public RelayCommand ExcluiVermifugoCommand
        {
            get;
            private set;
        }

        #endregion
        #region Propriedades
        Animal _animal;
        public Animal Animal
        {
            get
            {
                return _animal;
            }
            set
            {
                if (_animal != value)
                {
                    _animal = value;
                    RaisePropertyChanged(nameof(Animal));
                    CarregarFoto();
                }
            }
        }
        ObservableCollection<IAnimal> _listaItens;
        public ObservableCollection<IAnimal> ListaItens
        {
            get
            {
                return _listaItens;
            }
            set
            {
                if (_listaItens != value)
                {
                    _listaItens = value;
                    RaisePropertyChanged(nameof(ListaItens));
                }
            }
        }
        string _filtroPesquisa;
        public string FiltroPesquisa
        {
            get
            {
                return _filtroPesquisa;
            }
            set
            {
                if (_filtroPesquisa != value)
                {
                    _filtroPesquisa = value;
                    RaisePropertyChanged(nameof(FiltroPesquisa));
                }
            }
        }

        bool expanderAberto;
        public bool ExpanderAberto
        {
            get
            {
                return expanderAberto;
            }
            set
            {
                if (expanderAberto != value)
                {
                    expanderAberto = value;
                    RaisePropertyChanged(nameof(ExpanderAberto));
                }
            }
        }

        ObservableCollection<KeyValuePair<int, string>> _listaSexo;
        public ObservableCollection<KeyValuePair<int, string>> ListaSexo
        {
            get
            {
                return _listaSexo;
            }
            set
            {
                if (_listaSexo != value)
                {
                    _listaSexo = value;
                    RaisePropertyChanged(nameof(ListaSexo));
                }

            }
        }

        ObservableCollection<KeyValuePair<int, string>> _listaEspecie;
        public ObservableCollection<KeyValuePair<int, string>> ListaEspecie
        {
            get
            {
                return _listaEspecie;
            }
            set
            {
                if (_listaEspecie != value)
                {
                    _listaEspecie = value;
                    RaisePropertyChanged(nameof(ListaEspecie));
                }
            }
        }

        ObservableCollection<string> _listaRaca;
        public ObservableCollection<string> ListaRaca
        {
            get
            {
                return _listaRaca;
            }
            set
            {
                if (_listaRaca != value)
                {
                    _listaRaca = value;
                    RaisePropertyChanged(nameof(ListaRaca));
                }
            }
        }

        ObservableCollection<KeyValuePair<int, string>> _listaAmbiente;
        public ObservableCollection<KeyValuePair<int, string>> ListaAmbiente
        {
            get
            {
                return _listaAmbiente;
            }
            set
            {
                if (_listaAmbiente != value)
                {
                    _listaAmbiente = value;
                    RaisePropertyChanged(nameof(ListaAmbiente));
                }
            }
        }

        public ObservableCollection<string> _listaTipoVacina;
        public ObservableCollection<string> ListaTipoVacina
        {
            get
            {
                return _listaTipoVacina;
            }
            set
            {
                if (_listaTipoVacina != value)
                {
                    _listaTipoVacina = value;
                    RaisePropertyChanged(nameof(ListaTipoVacina));
                }
            }
        }

        public ObservableCollection<IVacinaVermifugo> _listaTipoVermifugo;
        public ObservableCollection<IVacinaVermifugo> ListaTipoVermifugo
        {
            get
            {
                return _listaTipoVermifugo;
            }
            set
            {
                if (_listaTipoVermifugo != value)
                {
                    _listaTipoVermifugo = value;
                    RaisePropertyChanged(nameof(ListaTipoVermifugo));
                }
            }
        }
        public ObservableCollection<string> _listaFabricanteVermifugo;
        public ObservableCollection<string> ListaFabricanteVermifugo
        {
            get
            {
                return _listaFabricanteVermifugo;
            }
            set
            {
                if (_listaFabricanteVermifugo != value)
                {
                    _listaFabricanteVermifugo = value;
                    RaisePropertyChanged(nameof(ListaFabricanteVermifugo));
                }
            }
        }
        IVacinaVermifugo _vacinaSelecionada;
        public IVacinaVermifugo VacinaSelecionada
        {
            get
            {
                return _vacinaSelecionada;
            }
            set
            {
                if (_vacinaSelecionada != value)
                {
                    _vacinaSelecionada = value;
                    RaisePropertyChanged(nameof(VacinaSelecionada));
                }
            }
        }
        IVacinaVermifugo _vermifugoSelecionado;
        public IVacinaVermifugo VermifugoSelecionado
        {
            get
            {
                return _vermifugoSelecionado;
            }
            set
            {
                if (_vermifugoSelecionado != value)
                {
                    _vermifugoSelecionado = value;
                    RaisePropertyChanged(nameof(VermifugoSelecionado));
                }
            }
        }

        public ObservableCollection<string> _listaFabricanteVacina;
        public ObservableCollection<string> ListaFabricanteVacina
        {
            get
            {
                return _listaFabricanteVacina;
            }
            set
            {
                if (_listaFabricanteVacina != value)
                {
                    _listaFabricanteVacina = value;
                    RaisePropertyChanged(nameof(ListaFabricanteVacina));
                }
            }
        }
        ObservableCollection<IPessoa> _listaClinicas;
        public ObservableCollection<IPessoa> ListaClinicas
        {
            get
            {
                return _listaClinicas;
            }
            set
            {
                if (_listaClinicas != value)
                {
                    _listaClinicas = value;
                    RaisePropertyChanged(nameof(ListaClinicas));
                }
            }
        }

        BitmapImage _foto;
        public BitmapImage Foto
        {
            get
            {
                return _foto;
            }
            set
            {
                if (_foto != value)
                {
                    _foto = value;
                    RaisePropertyChanged(nameof(Foto));
                }
            }
        }

        #endregion
        public AnimalViewModel()
        {
            SetarCommands();
            CarregarListas();
            RefreshLista();
            ExpanderAberto = true;

        }

        private void SetarCommands()
        {
            this.SalvarCommand = new RelayCommand(Salvar, () => Animal != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.ExcluiCommand = new RelayCommand(Excluir, () => Animal != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Excluir));
            this.PesquisaCommand = new RelayCommand(Pesquisar);
            this.NovoItemCommand = new RelayCommand(CriarNovoItem, ()=> Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Adicionar));
            this.SelecaoFotoCommand = new RelayCommand(SelecaoFoto, () => Animal != null && Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.NovaVacinaCommand = new RelayCommand(NovaVacina, () => Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.ExcluiVacinaCommand = new RelayCommand(ExcluiVacina, ()=> Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.NovaVermifugoCommand = new RelayCommand(NovoVermifugo, () => Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.ExcluiVermifugoCommand = new RelayCommand(ExcluiVermifugo, () => Util.ValidarPermissao(Config.UsuarioAtual, PermissaoAtividadeUsuario.Alterar));
            this.VacinaSelecionada = new VacinaVermifugo();
            this.VermifugoSelecionado = new VacinaVermifugo();
        }

        private void SelecaoFoto()
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            // Set filter for file extension and default file extension 
            dlg.DefaultExt = "*.png";
            dlg.Filter = "PNG  (*.png)|*.png|JPG (*.jpg)|*.jpg|JPEG  (*.jpeg)|*.jpeg|BMP (*.bmp)|*.bmp|TIF (*.tif)|*.tif*";

            // Display OpenFileDialog by calling ShowDialog method 
            if (!dlg.ShowDialog().GetValueOrDefault()) return;
            this.Animal.Foto = dlg.FileName;
            CarregarFoto();
        }

        private void CarregarFoto()
        {
            
            var imagem = _animal?.Foto??null;
            if (imagem == null)
            {
                Foto = null;
                return;
            }
            
            
            
            var uriSource = new Uri(imagem, UriKind.Absolute);
            this.Foto = new BitmapImage(uriSource);
        }

        private void CarregarListas()
        {
            this.ListaEspecie = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaEspecieAnimal());
            this.ListaSexo = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaGeneroAnimal());
            this.ListaAmbiente = new ObservableCollection<KeyValuePair<int, string>>(Config.ObterListaAmbientesAnimal());
            this.ListaFabricanteVacina = new ObservableCollection<string>(Config.ObterListaFabricantesVacina());
            this.ListaFabricanteVermifugo = new ObservableCollection<string>(Config.ObterListaFabricantesVermifugo());
            this.ListaTipoVacina = new ObservableCollection<string>(Config.ObterListaTiposVacina());
            this.ListaRaca = new ObservableCollection<string>(Config.ObterRacasCaes());
            this.ListaClinicas = new ObservableCollection<IPessoa>(Util.Repositorio.ObterLista<Pessoa>(null, "Clinicas"));
        }

        private void ExcluiVermifugo()
        {
            this.Animal.Vermifugos.Remove(_vermifugoSelecionado);
            this.VermifugoSelecionado = null;
        }

        private void NovoVermifugo()
        {
            this.Animal.Vermifugos.Add(_vermifugoSelecionado);
            this.VermifugoSelecionado = null;

        }

        private void NovaVacina()
        {
            this.Animal.Vacinas.Add(_vacinaSelecionada);
            this.VacinaSelecionada = null;
        }

        private void ExcluiVacina()
        {
            this.Animal.Vacinas.Remove(_vacinaSelecionada);
            this.VacinaSelecionada = null;
        }

        private void RefreshLista(Func<Animal, bool> expression = null)
        {
            var lista = Util.Repositorio.ObterAnimal(expression).OrderBy(p => p.Nome);
            this.ListaItens = new ObservableCollection<IAnimal>(lista);
        }

        private void CriarNovoItem()
        {
            var animal = new Animal() { DataCadastro = DateTime.Now };
            if (Util.Repositorio.ObterLista<Animal>().Any())
            {
                var maxAtual = Util.Repositorio.ObterLista<Animal>().Max(p => p.Numero);
                animal.Numero = ++maxAtual;
            }
            else
            {
                animal.Numero = 1;
            }
            this.Animal = animal;
            ExpanderAberto = false;
        }

        private void Pesquisar()
        {
            if (string.IsNullOrWhiteSpace(FiltroPesquisa))
            {
                RefreshLista();
                return;
            }
            RefreshLista(x => x.Nome.Contains(FiltroPesquisa));
        }

        private void Excluir()
        {
            if (!Util.Repositorio.Apagar<Animal>(x => x.Id == this.Animal.Id))
            {
                return;
            }
            this.Animal = null;
            RefreshLista();
            ExpanderAberto = true;
        }

        private void Salvar()
        {
            if (!Util.Repositorio.Salvar<Animal>(_animal).Key)
            {
                return;
            }
            RefreshLista();
            ExpanderAberto = true;
        }
    }

}

