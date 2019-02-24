﻿using EM.Services.AlphaVantage.Entities;
using EM.Portal.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EM.Services.AlphaVantage.Entities.ApiQueries;
using EM.Services.HttpClientConsole.ApiClient;

namespace EM.Portal.Controllers
{
    public partial class DashboardController : Controller
    {
        // GET: Dashboard
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult OverView()
        {
            return View();
        }

        public virtual ActionResult Reports()
        {
            var stockTimeSeries = new StockTimeSeriesModel
            {
                Symbol = "MSFT",
                ApiKey = "3GKRGSLN9Y9CYXXF"
            };
            var stockTimeSeriescollection = new StockTimeSeriesDictionary(stockTimeSeries);

            var config = new Config
            {
                BaseUrl = "www.alphavantage.co",
                Schema = "https",
                Path = "query",
                Parameters = stockTimeSeriescollection
            };

            var metaData = new MetaData { };

            var model = new ReportViewModel
            {
                StockTimeSeries = stockTimeSeries,
                _config = config//,
                //MetaData = metaData
            };

            return View("Reports", model);
        }

        public virtual ActionResult ReportResults(ReportViewModel model)
        {
            var mf = new Functions.Master();
            var result = mf.GetDataAsync(model);
            //var model = new MetaData();

            //var json = JsonConvert.DeserializeObject<MetaData>(result);
            return View("Reports", result);
        }

        //public virtual async Task<ActionResult> _ReportResults()
        //{
        //    var mf = new Functions.Master();
        //    var model = await mf.GetDataAsync1();
        //    //var model = new MetaData();

        //    //var json = JsonConvert.DeserializeObject<MetaData>(result);
        //    return PartialView("Report/_ReportResults", model);
        //}

        public virtual ActionResult _ReportResults()
        {
            var mf = new Functions.Master();
            var model = mf.GetDataAsync1();
            //var model = new MetaData();

            //var json = JsonConvert.DeserializeObject<MetaData>(result);
            return PartialView("Report/_ReportResults", model);
        }

        public virtual JsonResult GetReports(ReportViewModel model)
        {
            #region test data
            var test = @"{
        'Meta Data': {
            '1. Information': 'Intraday (5min) open, high, low, close prices and volume',
            '2. Symbol': 'MSFT',
            '3. Last Refreshed': '2019-01-29 14:45:00',
            '4. Interval': '5min',
            '5. Output Size': 'Compact',
            '6. Time Zone': 'US/Eastern'
        },
        'Time Series (5min)': {
            '2019-01-29 14:45:00': {
                '1. open': '102.9200',
                '2. high': '102.9200',
                '3. low': '102.7500',
                '4. close': '102.7700',
                '5. volume': '129423'
            },
            '2019-01-29 14:40:00': {
                '1. open': '102.9750',
                '2. high': '102.9800',
                '3. low': '102.8950',
                '4. close': '102.9380',
                '5. volume': '200068'
            },
            '2019-01-29 14:35:00': {
                '1. open': '102.8300',
                '2. high': '103.0000',
                '3. low': '102.8000',
                '4. close': '102.9765',
                '5. volume': '165437'
            },
            '2019-01-29 14:30:00': {
                '1. open': '102.8248',
                '2. high': '102.8600',
                '3. low': '102.7800',
                '4. close': '102.8350',
                '5. volume': '150600'
            },
            '2019-01-29 14:25:00': {
                '1. open': '102.8980',
                '2. high': '102.9000',
                '3. low': '102.8200',
                '4. close': '102.8200',
                '5. volume': '436342'
            },
            '2019-01-29 14:20:00': {
                '1. open': '103.0100',
                '2. high': '103.0500',
                '3. low': '102.8900',
                '4. close': '102.9000',
                '5. volume': '226059'
            },
            '2019-01-29 14:15:00': {
                '1. open': '103.0500',
                '2. high': '103.0500',
                '3. low': '102.9800',
                '4. close': '103.0100',
                '5. volume': '162859'
            },
            '2019-01-29 14:10:00': {
                '1. open': '103.0400',
                '2. high': '103.0600',
                '3. low': '103.0250',
                '4. close': '103.0591',
                '5. volume': '181736'
            },
            '2019-01-29 14:05:00': {
                '1. open': '103.1132',
                '2. high': '103.1132',
                '3. low': '103.0000',
                '4. close': '103.0400',
                '5. volume': '250115'
            },
            '2019-01-29 14:00:00': {
                '1. open': '102.9900',
                '2. high': '103.1100',
                '3. low': '102.9900',
                '4. close': '103.1100',
                '5. volume': '282744'
            },
            '2019-01-29 13:55:00': {
                '1. open': '103.0092',
                '2. high': '103.0800',
                '3. low': '102.9600',
                '4. close': '102.9950',
                '5. volume': '283399'
            },
            '2019-01-29 13:50:00': {
                '1. open': '102.9600',
                '2. high': '103.0400',
                '3. low': '102.9600',
                '4. close': '103.0050',
                '5. volume': '154727'
            },
            '2019-01-29 13:45:00': {
                '1. open': '102.8650',
                '2. high': '102.9900',
                '3. low': '102.8190',
                '4. close': '102.9600',
                '5. volume': '261795'
            },
            '2019-01-29 13:40:00': {
                '1. open': '102.8600',
                '2. high': '102.8750',
                '3. low': '102.7900',
                '4. close': '102.8650',
                '5. volume': '139397'
            },
            '2019-01-29 13:35:00': {
                '1. open': '102.9000',
                '2. high': '102.9100',
                '3. low': '102.8550',
                '4. close': '102.8600',
                '5. volume': '292372'
            },
            '2019-01-29 13:30:00': {
                '1. open': '102.7900',
                '2. high': '102.9000',
                '3. low': '102.7700',
                '4. close': '102.8800',
                '5. volume': '244367'
            },
            '2019-01-29 13:25:00': {
                '1. open': '102.7500',
                '2. high': '102.8700',
                '3. low': '102.7300',
                '4. close': '102.7900',
                '5. volume': '459858'
            },
            '2019-01-29 13:20:00': {
                '1. open': '102.6700',
                '2. high': '102.7900',
                '3. low': '102.6600',
                '4. close': '102.7400',
                '5. volume': '235782'
            },
            '2019-01-29 13:15:00': {
                '1. open': '102.7150',
                '2. high': '102.7600',
                '3. low': '102.6500',
                '4. close': '102.6850',
                '5. volume': '219014'
            },
            '2019-01-29 13:10:00': {
                '1. open': '102.7750',
                '2. high': '102.8100',
                '3. low': '102.6400',
                '4. close': '102.7000',
                '5. volume': '282588'
            },
            '2019-01-29 13:05:00': {
                '1. open': '102.7600',
                '2. high': '102.8000',
                '3. low': '102.6600',
                '4. close': '102.7800',
                '5. volume': '236901'
            },
            '2019-01-29 13:00:00': {
                '1. open': '102.7650',
                '2. high': '102.8600',
                '3. low': '102.7600',
                '4. close': '102.7640',
                '5. volume': '229157'
            },
            '2019-01-29 12:55:00': {
                '1. open': '102.5550',
                '2. high': '102.7900',
                '3. low': '102.5543',
                '4. close': '102.7700',
                '5. volume': '302528'
            },
            '2019-01-29 12:50:00': {
                '1. open': '102.5450',
                '2. high': '102.6000',
                '3. low': '102.5200',
                '4. close': '102.5450',
                '5. volume': '138271'
            },
            '2019-01-29 12:45:00': {
                '1. open': '102.5900',
                '2. high': '102.6050',
                '3. low': '102.5300',
                '4. close': '102.5550',
                '5. volume': '208604'
            },
            '2019-01-29 12:40:00': {
                '1. open': '102.6301',
                '2. high': '102.6450',
                '3. low': '102.5300',
                '4. close': '102.5800',
                '5. volume': '216293'
            },
            '2019-01-29 12:35:00': {
                '1. open': '102.6098',
                '2. high': '102.6650',
                '3. low': '102.5850',
                '4. close': '102.6300',
                '5. volume': '266020'
            },
            '2019-01-29 12:30:00': {
                '1. open': '102.6310',
                '2. high': '102.6500',
                '3. low': '102.5842',
                '4. close': '102.5928',
                '5. volume': '176686'
            },
            '2019-01-29 12:25:00': {
                '1. open': '102.5350',
                '2. high': '102.6800',
                '3. low': '102.5317',
                '4. close': '102.6331',
                '5. volume': '338623'
            },
            '2019-01-29 12:20:00': {
                '1. open': '102.5228',
                '2. high': '102.5939',
                '3. low': '102.4750',
                '4. close': '102.5400',
                '5. volume': '395697'
            },
            '2019-01-29 12:15:00': {
                '1. open': '102.3000',
                '2. high': '102.5800',
                '3. low': '102.3000',
                '4. close': '102.5300',
                '5. volume': '342641'
            },
            '2019-01-29 12:10:00': {
                '1. open': '102.1900',
                '2. high': '102.3500',
                '3. low': '102.1900',
                '4. close': '102.2900',
                '5. volume': '424969'
            },
            '2019-01-29 12:05:00': {
                '1. open': '102.2800',
                '2. high': '102.3000',
                '3. low': '102.1800',
                '4. close': '102.2000',
                '5. volume': '518686'
            },
            '2019-01-29 12:00:00': {
                '1. open': '102.3748',
                '2. high': '102.4350',
                '3. low': '102.2825',
                '4. close': '102.2825',
                '5. volume': '275647'
            },
            '2019-01-29 11:55:00': {
                '1. open': '102.4600',
                '2. high': '102.4650',
                '3. low': '102.3704',
                '4. close': '102.3704',
                '5. volume': '302271'
            },
            '2019-01-29 11:50:00': {
                '1. open': '102.5300',
                '2. high': '102.5300',
                '3. low': '102.3700',
                '4. close': '102.4600',
                '5. volume': '440939'
            },
            '2019-01-29 11:45:00': {
                '1. open': '102.6200',
                '2. high': '102.7000',
                '3. low': '102.5375',
                '4. close': '102.5375',
                '5. volume': '344804'
            },
            '2019-01-29 11:40:00': {
                '1. open': '102.5100',
                '2. high': '102.6700',
                '3. low': '102.5000',
                '4. close': '102.6300',
                '5. volume': '263220'
            },
            '2019-01-29 11:35:00': {
                '1. open': '102.6100',
                '2. high': '102.6400',
                '3. low': '102.4100',
                '4. close': '102.5300',
                '5. volume': '478525'
            },
            '2019-01-29 11:30:00': {
                '1. open': '102.7000',
                '2. high': '102.7500',
                '3. low': '102.5800',
                '4. close': '102.6000',
                '5. volume': '400640'
            },
            '2019-01-29 11:25:00': {
                '1. open': '102.8900',
                '2. high': '102.8900',
                '3. low': '102.7200',
                '4. close': '102.7200',
                '5. volume': '238672'
            },
            '2019-01-29 11:20:00': {
                '1. open': '102.8900',
                '2. high': '102.9700',
                '3. low': '102.8300',
                '4. close': '102.8950',
                '5. volume': '243111'
            },
            '2019-01-29 11:15:00': {
                '1. open': '102.7900',
                '2. high': '102.8900',
                '3. low': '102.7900',
                '4. close': '102.8650',
                '5. volume': '235965'
            },
            '2019-01-29 11:10:00': {
                '1. open': '102.8400',
                '2. high': '102.9400',
                '3. low': '102.7597',
                '4. close': '102.7700',
                '5. volume': '444243'
            },
            '2019-01-29 11:05:00': {
                '1. open': '102.6100',
                '2. high': '102.8550',
                '3. low': '102.5100',
                '4. close': '102.8300',
                '5. volume': '599936'
            },
            '2019-01-29 11:00:00': {
                '1. open': '102.9700',
                '2. high': '102.9700',
                '3. low': '102.5300',
                '4. close': '102.6100',
                '5. volume': '836117'
            },
            '2019-01-29 10:55:00': {
                '1. open': '103.4301',
                '2. high': '103.4301',
                '3. low': '102.9800',
                '4. close': '102.9855',
                '5. volume': '668102'
            },
            '2019-01-29 10:50:00': {
                '1. open': '103.4800',
                '2. high': '103.5000',
                '3. low': '103.3500',
                '4. close': '103.4200',
                '5. volume': '350086'
            },
            '2019-01-29 10:45:00': {
                '1. open': '103.4850',
                '2. high': '103.5301',
                '3. low': '103.3500',
                '4. close': '103.4900',
                '5. volume': '530580'
            },
            '2019-01-29 10:40:00': {
                '1. open': '103.6400',
                '2. high': '103.6750',
                '3. low': '103.4600',
                '4. close': '103.4600',
                '5. volume': '486058'
            },
            '2019-01-29 10:35:00': {
                '1. open': '103.8900',
                '2. high': '103.9900',
                '3. low': '103.6300',
                '4. close': '103.6300',
                '5. volume': '429410'
            },
            '2019-01-29 10:30:00': {
                '1. open': '103.7800',
                '2. high': '103.9100',
                '3. low': '103.7500',
                '4. close': '103.8800',
                '5. volume': '305787'
            },
            '2019-01-29 10:25:00': {
                '1. open': '104.0000',
                '2. high': '104.0000',
                '3. low': '103.7400',
                '4. close': '103.7850',
                '5. volume': '535039'
            },
            '2019-01-29 10:20:00': {
                '1. open': '103.9400',
                '2. high': '104.0100',
                '3. low': '103.8700',
                '4. close': '104.0100',
                '5. volume': '344410'
            },
            '2019-01-29 10:15:00': {
                '1. open': '103.9000',
                '2. high': '103.9400',
                '3. low': '103.7800',
                '4. close': '103.9400',
                '5. volume': '394073'
            },
            '2019-01-29 10:10:00': {
                '1. open': '104.0581',
                '2. high': '104.0700',
                '3. low': '103.9100',
                '4. close': '103.9100',
                '5. volume': '467417'
            },
            '2019-01-29 10:05:00': {
                '1. open': '103.9400',
                '2. high': '104.1825',
                '3. low': '103.9400',
                '4. close': '104.0400',
                '5. volume': '652927'
            },
            '2019-01-29 10:00:00': {
                '1. open': '103.8900',
                '2. high': '103.9700',
                '3. low': '103.8700',
                '4. close': '103.9330',
                '5. volume': '506257'
            },
            '2019-01-29 09:55:00': {
                '1. open': '104.1850',
                '2. high': '104.2000',
                '3. low': '103.8500',
                '4. close': '103.8900',
                '5. volume': '476680'
            },
            '2019-01-29 09:50:00': {
                '1. open': '104.1200',
                '2. high': '104.3500',
                '3. low': '104.0700',
                '4. close': '104.1900',
                '5. volume': '438098'
            },
            '2019-01-29 09:45:00': {
                '1. open': '104.3400',
                '2. high': '104.4500',
                '3. low': '104.0900',
                '4. close': '104.1300',
                '5. volume': '513645'
            },
            '2019-01-29 09:40:00': {
                '1. open': '104.8800',
                '2. high': '104.9000',
                '3. low': '104.2800',
                '4. close': '104.3300',
                '5. volume': '570923'
            },
            '2019-01-29 09:35:00': {
                '1. open': '104.8753',
                '2. high': '104.9600',
                '3. low': '104.7700',
                '4. close': '104.8700',
                '5. volume': '1099735'
            },
            '2019-01-28 16:00:00': {
                '1. open': '104.8550',
                '2. high': '105.1200',
                '3. low': '104.8400',
                '4. close': '105.0900',
                '5. volume': '1697850'
            },
            '2019-01-28 15:55:00': {
                '1. open': '104.9000',
                '2. high': '104.9500',
                '3. low': '104.8200',
                '4. close': '104.8500',
                '5. volume': '551581'
            },
            '2019-01-28 15:50:00': {
                '1. open': '104.9200',
                '2. high': '105.0100',
                '3. low': '104.8900',
                '4. close': '104.8900',
                '5. volume': '335102'
            },
            '2019-01-28 15:45:00': {
                '1. open': '104.9700',
                '2. high': '105.0100',
                '3. low': '104.9234',
                '4. close': '104.9234',
                '5. volume': '300918'
            },
            '2019-01-28 15:40:00': {
                '1. open': '104.9800',
                '2. high': '105.0200',
                '3. low': '104.9700',
                '4. close': '104.9700',
                '5. volume': '280988'
            },
            '2019-01-28 15:35:00': {
                '1. open': '105.0100',
                '2. high': '105.0600',
                '3. low': '104.9300',
                '4. close': '104.9900',
                '5. volume': '411054'
            },
            '2019-01-28 15:30:00': {
                '1. open': '105.0819',
                '2. high': '105.0900',
                '3. low': '105.0100',
                '4. close': '105.0200',
                '5. volume': '271469'
            },
            '2019-01-28 15:25:00': {
                '1. open': '105.0400',
                '2. high': '105.1300',
                '3. low': '105.0200',
                '4. close': '105.0900',
                '5. volume': '274183'
            },
            '2019-01-28 15:20:00': {
                '1. open': '105.1000',
                '2. high': '105.1000',
                '3. low': '105.0000',
                '4. close': '105.0333',
                '5. volume': '258558'
            },
            '2019-01-28 15:15:00': {
                '1. open': '105.0200',
                '2. high': '105.1500',
                '3. low': '105.0100',
                '4. close': '105.1100',
                '5. volume': '223123'
            },
            '2019-01-28 15:10:00': {
                '1. open': '105.0700',
                '2. high': '105.0850',
                '3. low': '104.9550',
                '4. close': '105.0200',
                '5. volume': '256657'
            },
            '2019-01-28 15:05:00': {
                '1. open': '104.9800',
                '2. high': '105.1000',
                '3. low': '104.9800',
                '4. close': '105.0700',
                '5. volume': '271517'
            },
            '2019-01-28 15:00:00': {
                '1. open': '105.1200',
                '2. high': '105.1600',
                '3. low': '104.9800',
                '4. close': '104.9900',
                '5. volume': '345826'
            },
            '2019-01-28 14:55:00': {
                '1. open': '105.1050',
                '2. high': '105.2200',
                '3. low': '105.1000',
                '4. close': '105.1200',
                '5. volume': '341703'
            },
            '2019-01-28 14:50:00': {
                '1. open': '105.0000',
                '2. high': '105.1200',
                '3. low': '105.0000',
                '4. close': '105.1100',
                '5. volume': '256385'
            },
            '2019-01-28 14:45:00': {
                '1. open': '105.0500',
                '2. high': '105.0700',
                '3. low': '104.9600',
                '4. close': '105.0007',
                '5. volume': '216726'
            },
            '2019-01-28 14:40:00': {
                '1. open': '105.0300',
                '2. high': '105.0800',
                '3. low': '104.9600',
                '4. close': '105.0550',
                '5. volume': '144211'
            },
            '2019-01-28 14:35:00': {
                '1. open': '104.9100',
                '2. high': '105.0500',
                '3. low': '104.9100',
                '4. close': '105.0350',
                '5. volume': '196067'
            },
            '2019-01-28 14:30:00': {
                '1. open': '104.9000',
                '2. high': '104.9200',
                '3. low': '104.8500',
                '4. close': '104.9200',
                '5. volume': '144054'
            },
            '2019-01-28 14:25:00': {
                '1. open': '105.0050',
                '2. high': '105.0700',
                '3. low': '104.8924',
                '4. close': '104.8924',
                '5. volume': '197451'
            },
            '2019-01-28 14:20:00': {
                '1. open': '104.9300',
                '2. high': '105.0115',
                '3. low': '104.8900',
                '4. close': '105.0050',
                '5. volume': '216843'
            },
            '2019-01-28 14:15:00': {
                '1. open': '104.9200',
                '2. high': '104.9400',
                '3. low': '104.8650',
                '4. close': '104.9300',
                '5. volume': '203504'
            },
            '2019-01-28 14:10:00': {
                '1. open': '104.9100',
                '2. high': '104.9550',
                '3. low': '104.9000',
                '4. close': '104.9300',
                '5. volume': '135861'
            },
            '2019-01-28 14:05:00': {
                '1. open': '105.0150',
                '2. high': '105.0950',
                '3. low': '104.9000',
                '4. close': '104.9000',
                '5. volume': '412590'
            },
            '2019-01-28 14:00:00': {
                '1. open': '105.0500',
                '2. high': '105.0650',
                '3. low': '104.9900',
                '4. close': '105.0000',
                '5. volume': '174705'
            },
            '2019-01-28 13:55:00': {
                '1. open': '105.0200',
                '2. high': '105.1100',
                '3. low': '105.0100',
                '4. close': '105.0400',
                '5. volume': '179026'
            },
            '2019-01-28 13:50:00': {
                '1. open': '104.9950',
                '2. high': '105.0300',
                '3. low': '104.9700',
                '4. close': '105.0200',
                '5. volume': '140944'
            },
            '2019-01-28 13:45:00': {
                '1. open': '105.0000',
                '2. high': '105.0200',
                '3. low': '104.9800',
                '4. close': '104.9950',
                '5. volume': '116388'
            },
            '2019-01-28 13:40:00': {
                '1. open': '105.0000',
                '2. high': '105.0500',
                '3. low': '104.9700',
                '4. close': '105.0050',
                '5. volume': '150284'
            },
            '2019-01-28 13:35:00': {
                '1. open': '104.9500',
                '2. high': '105.0400',
                '3. low': '104.9499',
                '4. close': '105.0000',
                '5. volume': '200717'
            },
            '2019-01-28 13:30:00': {
                '1. open': '104.9650',
                '2. high': '105.0000',
                '3. low': '104.9000',
                '4. close': '104.9500',
                '5. volume': '198309'
            },
            '2019-01-28 13:25:00': {
                '1. open': '104.9100',
                '2. high': '105.0900',
                '3. low': '104.8900',
                '4. close': '104.9750',
                '5. volume': '226471'
            },
            '2019-01-28 13:20:00': {
                '1. open': '104.8400',
                '2. high': '104.9100',
                '3. low': '104.8200',
                '4. close': '104.9080',
                '5. volume': '140164'
            },
            '2019-01-28 13:15:00': {
                '1. open': '104.7750',
                '2. high': '104.8550',
                '3. low': '104.7700',
                '4. close': '104.8350',
                '5. volume': '143996'
            },
            '2019-01-28 13:10:00': {
                '1. open': '104.7100',
                '2. high': '104.8150',
                '3. low': '104.6800',
                '4. close': '104.7650',
                '5. volume': '213009'
            },
            '2019-01-28 13:05:00': {
                '1. open': '104.7300',
                '2. high': '104.7600',
                '3. low': '104.6610',
                '4. close': '104.7200',
                '5. volume': '168913'
            },
            '2019-01-28 13:00:00': {
                '1. open': '104.8300',
                '2. high': '104.8300',
                '3. low': '104.7000',
                '4. close': '104.7600',
                '5. volume': '287372'
            }
        }}";
            #endregion
            var result = JsonConvert.SerializeObject(test);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        // GET: Dashboard/Details/5
        public virtual ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dashboard/Create
        public virtual ActionResult Create()
        {
            return View();
        }

        // POST: Dashboard/Create
        [HttpPost]
        public virtual ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Edit/5
        public virtual ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Dashboard/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Dashboard/Delete/5
        public virtual ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dashboard/Delete/5
        [HttpPost]
        public virtual ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
