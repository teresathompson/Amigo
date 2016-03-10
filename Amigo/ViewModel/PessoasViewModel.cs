﻿using AmigoRepo;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amigo.ViewModel
{
    public class PessoasViewModel : ViewModelBase
    {
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

        IPessoa _pessoa;
        public IPessoa Pessoa
        {
            get
            {
                return _pessoa;
            }
            set
            {
                if (_pessoa != value)
                {
                    _pessoa = value;
                    RaisePropertyChanged(nameof(Pessoa));
                }
            }
        }

        ObservableCollection<IChaveValor<int, string>> _listaCategorias;
        public ObservableCollection<IChaveValor<int, string>> ListaCategorias
        {
            get
            {
                return _listaCategorias;
            }
            set
            {
                if (_listaCategorias != value)
                {
                    _listaCategorias = value;
                    RaisePropertyChanged(nameof(ListaCategorias));
                }
            }
        }
        ObservableCollection<IChaveValor<int, string>> _listaTipos;
        public ObservableCollection<IChaveValor<int, string>> ListaTipos
        {
            get
            {
                return _listaTipos;
            }
            set
            {
                if (_listaTipos != value)
                {
                    _listaTipos = value;
                    RaisePropertyChanged(nameof(ListaTipos));
                }
            }
        }
        ObservableCollection<IChaveValor<int, string>> _listaSatus;
        public ObservableCollection<IChaveValor<int, string>> ListaStatus
        {
            get
            {
                return _listaSatus;
            }
            set
            {
                if (_listaSatus != value)
                {
                    _listaSatus = value;
                    RaisePropertyChanged(nameof(ListaStatus));
                }
            }
        }

        ObservableCollection<IRepositorio> _listaItens;
        public ObservableCollection<IRepositorio> ListaItens
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


        public RelayCommand AlteraCommand { get; private set; }

        //bool podeAlterar = true;
        bool podeSalvar = true;
        bool podeExcluir = true;

        public PessoasViewModel()
        {

            //Messenger.Default.Register<PessoaMessageArgs>(this, PessoaEnviada);
            this.SalvarCommand = new RelayCommand(Salvar, () => podeSalvar);
            this.ExcluiCommand = new RelayCommand(Excluir, () => podeExcluir);
            this.PesquisaCommand = new RelayCommand(Pesquisar);

            var cat = new List<IChaveValor<int, string>>();
            cat.Add(new ChaveValor<int, string>() { Chave = 1, Valor = "Fundador" });
            cat.Add(new ChaveValor<int, string>() { Chave = 2, Valor = "Efetivo" });
            cat.Add(new ChaveValor<int, string>() { Chave = 3, Valor = "Colaborador" });
            cat.Add(new ChaveValor<int, string>() { Chave = 4, Valor = "Honorario" });
            cat.Add(new ChaveValor<int, string>() { Chave = 5, Valor = "Mirim" });

            this.ListaCategorias = new ObservableCollection<IChaveValor<int, string>>(cat);

            var tipos = new List<IChaveValor<int, string>>();
            tipos.Add(new ChaveValor<int, string>() { Chave = 1, Valor = "Normal" });
            tipos.Add(new ChaveValor<int, string>() { Chave = 2, Valor = "Diretoria" });
            tipos.Add(new ChaveValor<int, string>() { Chave = 3, Valor = "Voluntário" });

            this.ListaTipos = new ObservableCollection<IChaveValor<int, string>>(tipos);


            var status = new List<IChaveValor<int, string>>();
            status.Add(new ChaveValor<int, string>() { Chave = 1, Valor = "Ativo" });
            status.Add(new ChaveValor<int, string>() { Chave = 2, Valor = "Pendente" });
            status.Add(new ChaveValor<int, string>() { Chave = 3, Valor = "Inativo" });

            this.ListaStatus = new ObservableCollection<IChaveValor<int, string>>(status);
            NovoItemCommand = new RelayCommand(CriarNovoItem);
            RefreshLista();


        }

        private void CriarNovoItem()
        {
            this.Pessoa = new Pessoa();
            Pessoa.Numero = Util.Repositorio.ObterLista<Pessoa>().DefaultIfEmpty().Max(p => p.Numero) + 1;
        }

        

        private void Salvar()
        {
            if (Util.Repositorio.Salvar<Pessoa>(this.Pessoa as Pessoa).Key)
            {
                RefreshLista();
            }

        }

        private void Excluir()
        {
            Util.Repositorio.Apagar<Pessoa>(x => x.Id == this.Pessoa.Id);
        }

        private void Pesquisar()
        {
            throw new NotImplementedException();
        }

        private void Alterar()
        {
            throw new NotImplementedException();
        }
        private void RefreshLista()
        {
            var lista = Util.Repositorio.ObterLista<Pessoa>();
            this.ListaItens = new ObservableCollection<IRepositorio>(lista);
        }
    }
}
