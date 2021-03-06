﻿using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ToDoApp.Application.Common.Interfaces;
using ToDoApp.Application.Notifications.Models;

namespace ToDoApp.Application.ToDoItems.Commands.UpdateToDoItem
{
    public class ToDoItemUpdated:INotification
    {
        public Guid UserId { get; set; }
        public Guid ToDoId { get; set; }

        public class Handler:INotificationHandler<ToDoItemUpdated>
        {
            private readonly INotificationService _notificationService;

            public Handler(INotificationService notificationService)
            {
                _notificationService = notificationService;
            }


            public async Task Handle(ToDoItemUpdated notification, CancellationToken cancellationToken)
            {
                await _notificationService.Notify(new TodoUpdatedNotificationDto()
                {
                    UserId = notification.UserId,
                    ToDoId = notification.ToDoId
                });
            }
        }
    }
    
    }
