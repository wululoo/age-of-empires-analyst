using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppKit;
using Foundation;
using Newtonsoft.Json;
using Rest.Net;
using AgeOfEmpiresLibrary;
using Firebase.Database;
using Firebase.Database.Query;

namespace GameAnalyser
{
	public partial class ViewController : NSViewController
	{
        public FirebaseClient firebaseClient;

		public ViewController(IntPtr handle) : base(handle)
		{
		}

        public class Test 
        {
            public int Duration;
            public string Name;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Do any additional setup after loading the view.

            //Testing();

        }

   //     public async void Testing()
   //     {
			//var auth = "GrXh9SxG47RXNrUBuZecm1hpf6dc2kWbWfql7UJF";
			//firebaseClient = new FirebaseClient(
			//	"https://aoe-analyst.firebaseio.com/",
			//	new FirebaseOptions
			//	{
			//		AuthTokenAsyncFactory = () => Task.FromResult(auth)
			//	}
			//);

        //}

        public override NSObject RepresentedObject
		{
			get
			{
				return base.RepresentedObject;
			}
			set
			{
				base.RepresentedObject = value;
				// Update the view, if already loaded.
			}
		}

		partial void ClickedButton(Foundation.NSObject sender)
		{
			RecordedGame recordedGame;

			var dlg = NSOpenPanel.OpenPanel;
			dlg.CanChooseFiles = true;
			dlg.CanChooseDirectories = false;
			dlg.AllowedFileTypes = new string[] { "aoe2spgame", "aoe2record", "mgx", "mgz" };

			StreamExtractor stream;

			if (dlg.RunModal() == 1)
			{
				// Nab the first file
				var url = dlg.Urls[0];

				if (url != null)
				{
					var path = url.Path;

					stream = new StreamExtractor(url.Path);
					HeaderLabel.Value = stream.getHeaderContent();
					HeaderLabel2.Value = BitConverter.ToString(stream.getHeaderByteArray());
					BodyLabel.Value = stream.getBodyContent();
					BodyLabel2.Value = BitConverter.ToString(stream.getBodyByteArray());
					FileNameLabel.StringValue = url.Path;

					try
					{
                        recordedGame = Analyser.analyseGameROR(stream.getHeaderByteList(), stream.getBodyByteList(), stream.getFileName(), stream.getFileFormat());
                        //GameRoom gr = AgeOfEmpiresLibrary.Classes.Parser.getGameRoomWK(stream.getHeaderByteArray());
                        BodyLabel.Value = recordedGame.exportMainJSON();
						Version.StringValue = recordedGame.getVersion().ToString();
                        HeaderLabel2.Value = AgeOfEmpiresLibrary.Classes.Parser.getGameRoom(stream.getHeaderByteArray()).exportJSON();
						//SubVersion.StringValue = recordedGame.getSubVersion().ToString();
					}
					catch (Exception e)
					{
						BodyLabel.Value = e.ToString();
					}
				}
			}
		}
	}
}
