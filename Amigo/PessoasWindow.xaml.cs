﻿using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Amigo
{
    /// <summary>
    /// Interaction logic for PessoasWindow.xaml
    /// </summary>
    public partial class PessoasWindow : Window
    {
        public PessoasWindow()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseWindowMessage>(this,"PessoasWindow", _ => Close());
        }
    }
}
