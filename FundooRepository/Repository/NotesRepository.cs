// --------------------------------------------------------------------------------------------------------------------
// <copyright file=NotesRepository.cs" company="Bridgelabz">
//   Copyright © 2019 Company="BridgeLabz"
// </copyright>
// <creator name="Sachin Kumar Maurya"/>
// --------------------------------------------------------------------------------------------------------------------
namespace FundooRepository.Repository
{
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Common.Models.NotesModels;
    using FundooRepository.Context;
    using FundooRepository.Intefaces;
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Web;
    using Nancy.Json;
    //using System.Messaging;


    /// <summary>
    /// NotesRepository is a class which inherited the INotesRepository
    /// </summary>
    public class NotesRepository : INotesRepository
    {
        private readonly UserContext _context;
        private readonly ICacheProvider _cacheProvider;
        /// <summary>
        /// NotesRepository is constructor for initailizing
        /// </summary>
        /// <param name="context"></param>
        public NotesRepository(UserContext context, ICacheProvider cacheProvider)
        {
            _context = context;
            _cacheProvider = cacheProvider;
        }
        /// <summary>
        /// Create is method for add the data in our notes table  with Jwt Authentication 
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task Create(NotesModel notes, string email, string key)
        {
            var result = _context.Users.Where(i => i.Email == email).FirstOrDefault();
            if (result != null)
            {
                notes.Email = email;
                var note = new NotesModel()
                {
                    Id = notes.Id,
                    Email = notes.Email,
                    Title = notes.Title,
                    Description = notes.Description,
                    CreatedDate = DateTime.Now,
                    IndexValue = AddIndexValue(email)

                };
                _context.Notes.Add(note);
                var value= _context.SaveChanges();
                SetValue(email, key);
                result.TotalNotes++;
            }
            else
            {
                return null;
            }
           
            //var result = Test_GetValue(email.ToUpper());
            //result.Add(note);
            // _cacheProvider.Set(email.ToUpper(), result);
            return Task.Run(() => _context.SaveChanges());
        }
        /// <summary>
        /// RetrieveById is method which has retrieving the data of particular Id  with Jwt Authentication 
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<NotesModel> RetrieveById(int Id, string email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == Id);
           // var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (value1 != null)
            {
                if (value1.Email.Equals(email))
                {
                    return Task.Run(() => value1);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Delete is method for deleting the particular id  with Jwt Authentication 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Task Delete(int ID, string Email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == ID);
            var result = _context.Users.Where(j => j.Email == Email).FirstOrDefault();
            if (value1.Email.Equals(Email))
            {
                if (value1 != null)
                {
                    result.TotalNotes--;
                    _context.Notes.Remove(value1);
                    value.Remove(value1);
                    _cacheProvider.Set(key, value);
                }
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Update is a method which has updated the data by its particular Id with Jwt Authentication 
        /// </summary>
        /// <param name="notes"></param>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Task Update(NotesModel notes, string Email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == notes.Id);
            //var result = _context.Notes.Where(j => j.Id == notes.Id).FirstOrDefault();
            if (value1.Email.Equals(Email))
            {
                if (value1 != null)
                {
                    value1.Title = notes.Title;
                    value1.Description = notes.Description;
                    value1.ModifiedDate = DateTime.Now;
                    _context.Notes.Update(value1);
                    _cacheProvider.Set(key, value);
                }
                return Task.Run(() => _context.SaveChanges());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Show is a mthod which shows all the related to login person  with Jwt Authentication 
        /// </summary>
        /// <param name="Email"></param>
        /// <returns></returns>
        public Task<List<NotesModel>> Show(string email, string key)
        {
            //bool note = _context.Notes.Any(p => p.Email == email);
            //if (note)
            //{
            //    // return Task.Run(() => _context.Notes.Where(p => (p.Email == Email) && (p.IsArchive==false) &&(p.IsTrash==false)).ToList());
            //   return Task.Run(()=> _context.Notes.Where(c =>( c.Email ==email) && (c.IsArchive == false) && (c.IsTrash == false)).OrderBy(s => s.IndexValue).ToList());
            //}
            //else
            //{
            //    return null;
            //}
            //SetValue(email);


           
            var result = Test_GetValue(key);
           // var result = _context.Notes.Where(i => i.Email == email || i.Collaborators.ReciverEamil==email).ToList();

            return Task.Run(()=>result);
        }
        public void SetValue(string email,string key)
        {
            var result = _context.Notes.Where(i => i.Email == email).ToList();
            _cacheProvider.Set(key, result);
        }
        /// <summary>
        /// Tests the get value from the Cache.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public List<NotesModel> Test_GetValue(string key)
        {
            var contacts = _cacheProvider.Get<List<NotesModel>>(key);
            return contacts;

        }
        /// <summary>
        /// Archives the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> Archive(int Id, string email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == Id);
            // var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (value1 != null)
            {
                if (value1.Email.Equals(email))
                {
                    value1.IsArchive = true;
                    try
                    {
                        _context.Notes.Update(value1);
                        var value2 = Task.Run(() => _context.SaveChanges());
                        _cacheProvider.Set(key, value);
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    //if (value.Equals(1))
                    //{
                    return Task.Run(() => true);
                    //}
                    //else
                    //{
                    //    return Task.Run(() => false);
                    //}
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Uns the archive.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> UnArchive(int Id, string email, string key)
        {
            var value = Test_GetValue(email.ToUpper());
            var value1 = value.Find(i => i.Id == Id);
            //var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (value1 != null)
            {
                if (value1.Email.Equals(email))
                {
                    value1.IsArchive = false;
                    try
                    {
                        _context.Notes.Update(value1);
                        var value2 = Task.Run(() => _context.SaveChanges());
                        _cacheProvider.Set(key, value);
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Pins the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> Pin(int Id, string email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == Id);
            //var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (value1 != null)
            {
                if (value1.Email.Equals(email))
                {
                    value1.IsPin = true;
                    try
                    {
                        _context.Notes.Update(value1);
                        var value2 = Task.Run(() => _context.SaveChanges());
                        _cacheProvider.Set(key, value);
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Uns the pin.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> UnPin(int Id, string email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == Id);
            // var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (value1 != null)
            {
                if (value1.Email.Equals(email))
                {
                    value1.IsPin = false;
                    try
                    {
                        _context.Notes.Update(value1);
                        var value2 = Task.Run(() => _context.SaveChanges());
                        _cacheProvider.Set(key, value);
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Trashes the specified identifier.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> Trash(int Id, string email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == Id);
            //var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (value1 != null)
            {
                if (value1.Email.Equals(email))
                {
                    value1.IsTrash = true;
                    try
                    {
                        _context.Notes.Update(value1);
                        var value2 = Task.Run(() => _context.SaveChanges());
                        _cacheProvider.Set(key, value);
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Uns the trash.
        /// </summary>
        /// <param name="Id">The identifier.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> RestoreById(int Id, string email, string key)
        {
            var value = Test_GetValue(key);
            var value1 = value.Find(i => i.Id == Id);
            // var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (value1 != null)
            {
                if (value1.Email.Equals(email))
                {
                    value1.IsTrash = false;
                    try
                    {
                        _context.Notes.Update(value1);
                        var value2 = Task.Run(() => _context.SaveChanges());
                        _cacheProvider.Set(key, value);
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Restores all from trash.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> RestoreAllFromTrash(string email)
        {
            //var value = Test_GetValue(email.ToUpper());
            //var value1=value.Where(i=>);
            IEnumerable<NotesModel> list = _context.Notes.Where(i => i.Email == email).ToList();
            if (list !=null)
            {
                foreach (var i in list)
                {
                    if (i.IsTrash == true)
                    {
                        i.IsTrash = false;
                    }
                }
                try
                {
                    var value = Task.Run(() => _context.SaveChanges());
                }
                catch (Exception)
                {
                    return Task.Run(() => false);
                }
                return Task.Run(() => true);
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// DeleteAll notes with Particular Id
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<bool> DeleteAll(string email)
        {
            IEnumerable<NotesModel> list = _context.Notes.Where(i => i.Email == email).ToList();
            if (list != null)
            {
                _context.Notes.RemoveRange(list);
                try
                {
                    var value = Task.Run(() => _context.SaveChanges());
                }
                catch (Exception)
                {
                    return Task.Run(() => false);
                }
                return Task.Run(() => true);
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// ImageUpload in Notes By Using Cloudinary
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="file"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<bool> ImageUpload(int Id, IFormFile file,string email)
        {
            var path = file.OpenReadStream();
            var File =file.FileName;
            CloudinaryDotNet.Account account = new CloudinaryDotNet.Account("dtil5iw6l", "562314371245223", "rvy_ZB_bMoq7pva8whrFXOcBprI");
            CloudinaryDotNet.Cloudinary cloudinary = new CloudinaryDotNet.Cloudinary(account);
            var image = new ImageUploadParams()
            {
                File = new FileDescription(File,path)
            };
            var uploadResult = cloudinary.Upload(image);
            if (uploadResult.Error != null)
                throw new Exception(uploadResult.Error.Message);
            var result = _context.Notes.Where(i => i.Id == Id).FirstOrDefault();
            if (result!=null)
            {
                if(result.Email.Equals(email))
                {
                    result.Images = uploadResult.Uri.ToString();
                    try
                    {
                        var value = Task.Run(() => _context.SaveChanges());
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Reminders the specified note.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> Reminder(NotesModel note, string email)
        {
            var result = _context.Notes.Where(i => i.Id == note.Id).FirstOrDefault();
            if (result != null)
            {
                if (result.Email.Equals(email))
                {
                    result.Reminder = note.Reminder;
                    try
                    {
                        var value = Task.Run(() => _context.SaveChanges());
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Removes the reminder.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task<bool> RemoveReminder(NotesModel note, string email)
        {
            var result = _context.Notes.Where(i => i.Id == note.Id).FirstOrDefault();
            if (result != null)
            {
                if (result.Email.Equals(email))
                {
                    result.Reminder =null;
                    try
                    {
                        var value = Task.Run(() => _context.SaveChanges());
                    }
                    catch (Exception)
                    {
                        return Task.Run(() => false);
                    }
                    return Task.Run(() => true);
                }
                else
                {
                    return Task.Run(() => false);
                }
            }
            else
            {
                return Task.Run(() => false);
            }
        }
        /// <summary>
        /// Sets the color.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public Task SetColor(NotesModel model,string email)
        {
            var result = _context.Notes.Where(i => i.Id == model.Id).FirstOrDefault();
            if(result!=null)
            {
                if(result.Email.Equals(email))
                {
                    result.Color = model.Color;
                    return Task.Run(() =>_context.SaveChanges());
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the list from trash.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task<List<NotesModel>> GetListFromTrash(string Email)
        {
            bool note = _context.Notes.Any(p => p.Email == Email);
            if (note)
            {
                return Task.Run(() => _context.Notes.Where(p => (p.Email == Email)  && (p.IsTrash == true)).ToList());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the list from archive.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task<List<NotesModel>> GetListFromArchive(string Email)
        {
            bool note = _context.Notes.Any(p => p.Email == Email);
            if (note)
            {
                return Task.Run(() => _context.Notes.Where(p => (p.Email == Email) && (p.IsArchive == true) && (p.IsTrash == false) && (p.IsPin == false)).ToList());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the list from reminder.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task<List<NotesModel>> GetListFromReminder(string Email)
        {
            bool note = _context.Notes.Any(p => p.Email == Email);
            if (note)
            {
                return Task.Run(() => _context.Notes.Where(p => (p.Email == Email) && (p.Reminder!=null) && (p.IsTrash == false)).ToList());
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Gets the list from pin.
        /// </summary>
        /// <param name="Email">The email.</param>
        /// <returns></returns>
        public Task<List<NotesModel>> GetListFromPin(string Email)
        {
            bool note = _context.Notes.Any(p => p.Email == Email);
            if (note)
            {
                return Task.Run(() => _context.Notes.Where(p => (p.Email == Email) && (p.IsPin == true) && (p.IsArchive == false) && (p.IsTrash == false)).ToList());
            }
            else
            {
                return null;
            }
        }
        ////Push Notification
        public Task PushNotification(NotificationModel obj)
        {
            try
            {
                var applicationID = "AIza---------4GcVJj4dI";

                var senderId = "57-------55";

                string deviceId = "euxqdp------ioIdL87abVL";

                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");

                tRequest.Method = "post";

                tRequest.ContentType = "application/json";

                var data = new

                {

                    to = deviceId,

                    notification = new

                    {

                        body = obj.Message,

                        title = obj.Tagmessage,

                        icon = "myicon"

                    }
                };

                var serializer = new JavaScriptSerializer();

                var json = serializer.Serialize(data);

                Byte[] byteArray = Encoding.UTF8.GetBytes(json);

                tRequest.Headers.Add(string.Format("Authorization: key={0}", applicationID));

                tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));

                tRequest.ContentLength = byteArray.Length;


                using (Stream dataStream = tRequest.GetRequestStream())
                {

                    dataStream.Write(byteArray, 0, byteArray.Length);


                    using (WebResponse tResponse = tRequest.GetResponse())
                    {

                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {

                            using (StreamReader tReader = new StreamReader(dataStreamResponse))
                            {

                                String sResponseFromServer = tReader.ReadToEnd();

                                string str = sResponseFromServer;

                            }
                        }
                    }
                }
            }

            catch (Exception ex)
            {

                string str = ex.Message;

            }
            return Task.Run(() => true);
        }
        /// <summary>
        /// AddIndexValue int notes for drag and drop
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int AddIndexValue(string email)
        {
            var result = _context.Notes.Where(i => i.Email == email).ToArray();
            if(result!=null)
            {
                int max = result[0].IndexValue;
               for(int i=0;i<result.Length;i++)
               {
                    if (result[i].IndexValue > max)
                        max = result[i].IndexValue;
               }
                return max + 1;
            }
            else
            {
                return 1;
            }
        }
        /// <summary>
        /// DragAndDrop for notes
        /// </summary>
        /// <param name="drag"></param>
        /// <param name="drop"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task DragAndDrop(int drag,int drop,string email)
        {
            var result = _context.Notes.Where(i => (i.Email == email) &&(i.IndexValue>=drag) &&(i.IndexValue<=drop)).ToArray();
                       
            if(result!=null)
            {
                if (drag < drop)
                {
                    for(int i=0;i<result.Length-1;i++)
                    {
                        if (result[i].IndexValue >= drag && result[i].IndexValue <= drop)
                        {
                            var temp = result[i].IndexValue;
                            result[i].IndexValue = result[i+1].IndexValue;
                            result[i+1].IndexValue = temp;
                        }
                    }
                    return Task.Run(() => _context.SaveChanges());
                }
                else
                {
                    var result1 = _context.Notes.Where(i => (i.Email == email) && (i.IndexValue <= drag) && (i.IndexValue >= drop)).ToArray();
                    for (int i = result1.Length - 1; i >0; i--)
                    {
                        if (result1[i].IndexValue <= drag && result1[i].IndexValue >= drop)
                        {
                            var temp = result1[i].IndexValue;
                            result1[i].IndexValue = result1[i-1].IndexValue;
                            result1[i-1].IndexValue = temp;
                        }
                    }
                    return Task.Run(() => _context.SaveChanges());
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Search is method for search the word which user has enter its has serarch in title of the notes
        /// </summary>
        /// <param name="searchString"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Task<List<NotesModel>> Search(string searchString, string email)
        {
            var listOfItem = _context.Notes.Where(t =>   (t.Email == email) && (t.Title.Contains(searchString)||t.Description.Contains(searchString)) && (t.IsArchive == false) && (t.IsTrash == false)).ToList();
            // var result = _context.Notes.Where(t => (t.Email == email)).FirstOrDefault();
            if (listOfItem.Count!=0)
            {
                //var listOfItem = _context.Notes.Where(t => t.Title.Contains(searchString) && (t.Email == email) && (t.IsArchive == false) && (t.IsTrash == false)).ToList();
                return Task.Run(() => listOfItem);
            }
            else
            {
                return null;
            }
        }
        //public Task PushMessage(string reminder)
        //{
        //    MessageQueue messageQueue = null;
        //    if (MessageQueue.Exists(@".\Private$\SomeTestName"))
        //    {
        //        messageQueue = new MessageQueue(@".\Private$\SomeTestName");
        //        messageQueue.Label = "Testing Queue";
        //    }
        //    else
        //    {
        //        // Create the Queue
        //        MessageQueue.Create(@".\Private$\SomeTestName");
        //        messageQueue = new MessageQueue(@".\Private$\SomeTestName");
        //        messageQueue.Label = "Newly Created Queue";
        //    }
        //    messageQueue.Send("First ever Message is sent to MSMQ", "Title");
        //    return Task.Run(()=>_context.SaveChanges());
        //}
        //public Task<Notes> show(string eamil)
        //{
        //    var result = _context.Notes.Where(c => c.Email == "d").OrderBy(s => s.IndexValue).ToList();

        //}
    }
}