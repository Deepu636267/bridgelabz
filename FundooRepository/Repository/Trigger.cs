//using Common.Models.UserModels;
//using FundooRepository.Context;
//using FundooRepository.Intefaces;
//using Microsoft.Extensions.Hosting;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace FundooRepository.Repository
//{
//    public class Trigger : BackgroundService
//    //{
//    //    private readonly UserContext _context;
//    //    public Trigger(UserContext context)
//    //    {
//    //        _context = context;
//    //    }
//        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
//        {
//            while(!stoppingToken.IsCancellationRequested)
//            {
//               _context.Users.Where(i => i.CardType == "advance");
//                await Task.Delay(10000, stoppingToken);
//            }
//        }
//    }
//}
