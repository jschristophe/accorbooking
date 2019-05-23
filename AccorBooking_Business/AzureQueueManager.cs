using System;

namespace AccorBooking.Business
{
    public class AzureQueueManager
    {
        public static CloudQueue CreateOrGetQueue()
        {
            // Retrieve storage account from connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageQueueConnectionString"));

            // Create the queue client.
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            // Retrieve a reference to a container.
            CloudQueue queue = queueClient.GetQueueReference("myqueue");

            // Create the queue if it doesn't already exist
            queue.CreateIfNotExists();

            return queue;
        }

        public static void InserMessageQueue(CloudQueue queue, string messagestring)
        {
            // Create a message and add it to the queue.
            CloudQueueMessage message = new CloudQueueMessage(messagestring);
            queue.AddMessage(message);
        }

        public static CloudQueueMessage GetMessageQueue(CloudQueue queue)
        {
            // Get the next message
            CloudQueueMessage retrievedMessage = queue.GetMessage();

            //Process the message in less than 30 seconds, and then delete the message
            queue.DeleteMessage(retrievedMessage);

            return retrievedMessage;
        }
    }
}
