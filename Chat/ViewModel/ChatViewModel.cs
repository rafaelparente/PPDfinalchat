﻿using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Threading.Tasks;
using Ch.Elca.Iiop;
using Chat.Interface;
using GalaSoft.MvvmLight;
using Chat.Model;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Threading;
using omg.org.CosNaming;
using System.Configuration;
using System.Collections.Specialized;
using System.Linq;
using GalaSoft.MvvmLight.Messaging;

namespace Chat.ViewModel
{
    public class ChatViewModel : ViewModelBase
    {
        /// <summary>
        /// The <see cref="PostText" /> property's name.
        /// </summary>
        public const string PostTextPropertyName = "PostText";

        private string _postText = string.Empty;

        /// <summary>
        /// Sets and gets the PostText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string PostText
        {
            get => this._postText;
            set => Set(() => this.PostText, ref this._postText, value);
        }

        /// <summary>
        /// The <see cref="Nickname" /> property's name.
        /// </summary>
        public const string NicknamePropertyName = "Nickname";

        private string _nickname = string.Empty;

        /// <summary>
        /// Sets and gets the Nickname property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string Nickname
        {
            get => _nickname;
            set => Set(() => Nickname, ref _nickname, value);
        }

        /// <summary>
        /// The <see cref="IsLoading" /> property's name.
        /// </summary>
        public const string IsLoadingPropertyName = "IsLoading";

        private bool _isLoading = false;

        /// <summary>
        /// Sets and gets the IsLoading property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsLoading
        {
            get => this._isLoading;
            set => Set(() => this.IsLoading, ref this._isLoading, value);
        }

        private RelayCommand _startCommand;

        /// <summary>
        /// Gets the StartCommand.
        /// </summary>
        public RelayCommand StartCommand =>
            this._startCommand ?? (this._startCommand = new RelayCommand(StartMethod,
                () => !string.IsNullOrEmpty(this.Nickname) && !this.IsLoading));

        private RelayCommand _postCommand;

        /// <summary>
        /// Gets the PostCommand.
        /// </summary>
        public RelayCommand PostCommand =>
            this._postCommand ?? (this._postCommand = new RelayCommand(PostMethod,
                () => !string.IsNullOrEmpty(this.PostText)));

        private ObservableCollection<ChatMsg> _chatMsgList;

        public ObservableCollection<ChatMsg> ChatMsgList
        {
            get => this._chatMsgList;
            set => Set(() => this.ChatMsgList, ref this._chatMsgList, value);
        }

        private NamingContext NameService { get; set; }

        private MessengerWS.MessengerItfClient WsClient { get; set; }


        public ChatViewModel()
        {
            this.ChatMsgList = new ObservableCollection<ChatMsg>();

            Messenger.Default.Register<ChatMsg>(this, "NewMsg", AddToChatMsgList);
        }

        private void StartMethod()
        {
            this.IsLoading = true;

            Task.Run(() =>
            {
                ConnectToServers();
                this.IsLoading = false;
                Messenger.Default.Send(this.Nickname, "Connected");
            });
        }

        private void ConnectToServers()
        {
            NameValueCollection serverConfig = ConfigurationManager.AppSettings;

            string nameServiceUrl = "corbaloc::" + serverConfig.Get("NameServerHost") +
                                    ":" + serverConfig.Get("NameServerPort") + "/NameService";

            IDictionary propBag = new Hashtable
            {
                ["port"] = 0,
                ["name"] = this.Nickname, // here enter unique channel name
            };

            // register the channel
            var chan = new IiopChannel(propBag);
            ChannelServices.RegisterChannel(chan, false);

            var svc = new ChatSvcImpl();
            RemotingServices.Marshal(svc, this.Nickname);

            var name = new[] { new NameComponent(this.Nickname) };

            // publish the svc with an external name service
            this.NameService = (NamingContext)RemotingServices.Connect(typeof(NamingContext), nameServiceUrl);
            this.NameService.rebind(name, svc);

            this.WsClient = new MessengerWS.MessengerItfClient();
        }

        private void PostMethod()
        {
            var newMsg = new MessengerWS.message()
            {
                Sender = this.Nickname,
                Content = this.PostText,
            };

            this.PostText = string.Empty;

            Task.Run(() =>
            {
                SendMessage(newMsg);
                var newChatMsg = new ChatMsg()
                {
                    Sender = newMsg.Sender,
                    Content = newMsg.Content,
                    IsSelfMessage = true,
                };
                AddToChatMsgList(newChatMsg);
            });
        }

        private void SendMessage(MessengerWS.message msg)
        {
            try
            {
                string testName = new string(this.Nickname.Reverse().ToArray());

                IDictionary propBag = new Hashtable()
                {
                    ["name"] = testName,  // here enter unique channel name
                };

                // register the channel
                var channel = new IiopClientChannel(propBag);
                ChannelServices.RegisterChannel(channel, false);

                var friendName = new[] { new NameComponent(testName) };

                // get the reference to the adder
                var friend = (IChatSvc)this.NameService.resolve(friendName);

                // call add
                friend.WriteMessage(msg);

                ChannelServices.UnregisterChannel(channel);
            }
            catch (Exception e)
            {
                Console.WriteLine(@"exception: " + e);
            }
        }

        private void AddToChatMsgList(ChatMsg chatMessage)
        {
            DispatcherHelper.CheckBeginInvokeOnUI(() => this.ChatMsgList.Add(chatMessage));
        }
    }
}
