﻿using Core.Domain;

namespace Core.DomainServices
{
    public interface INotificationService
    {
        void SendNotification(Notification notification);
    }
}
