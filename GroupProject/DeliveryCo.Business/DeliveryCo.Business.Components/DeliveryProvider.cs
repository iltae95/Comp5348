﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DeliveryCo.Business.Components.Interfaces;
using System.Transactions;
using DeliveryCo.Business.Entities;
using System.Threading;
using DeliveryCo.Services.Interfaces;


namespace DeliveryCo.Business.Components
{
    public class DeliveryProvider : IDeliveryProvider
    {
        public Guid SubmitDelivery(DeliveryCo.Business.Entities.DeliveryInfo pDeliveryInfo)
        {
            
            
                using (TransactionScope lScope = new TransactionScope())
                using (DeliveryCoEntityModelContainer lContainer = new DeliveryCoEntityModelContainer())
                {
                    pDeliveryInfo.DeliveryIdentifier = Guid.NewGuid();
                    pDeliveryInfo.Status = 0;
                    lContainer.DeliveryInfo.Add(pDeliveryInfo);
                    lContainer.SaveChanges();
                    ThreadPool.QueueUserWorkItem(new WaitCallback((pObj) => ScheduleDelivery(pDeliveryInfo)));
                
                    IDeliveryNotificationService lService = DeliveryNotificationServiceFactory.GetDeliveryNotificationService(pDeliveryInfo.DeliveryNotificationAddress);
                    lService.NotifyDeliverySubmitted(pDeliveryInfo.OrderNumber, pDeliveryInfo.DeliveryIdentifier, DeliveryInfoStatus.Submitted);

                    lScope.Complete();
                }
               return pDeliveryInfo.DeliveryIdentifier;
            
            //return pDeliveryInfo.DeliveryIdentifier;
        }

        private void ScheduleDelivery(DeliveryInfo pDeliveryInfo)
        {
            Console.WriteLine("Delivering to" + pDeliveryInfo.DestinationAddress);
            Thread.Sleep(3000);
            //notifying of delivery completion
            using (TransactionScope lScope = new TransactionScope())
            using (DeliveryCoEntityModelContainer lContainer = new DeliveryCoEntityModelContainer())
            {
                pDeliveryInfo.Status = 1;
                IDeliveryNotificationService lService = DeliveryNotificationServiceFactory.GetDeliveryNotificationService(pDeliveryInfo.DeliveryNotificationAddress);
                lService.NotifyDeliveryCompletion(pDeliveryInfo.DeliveryIdentifier, DeliveryInfoStatus.Delivered);
                lScope.Complete();
            }

        }
    }
}
