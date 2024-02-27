List<LottoTip> lottoTipes = await FileService.GetLottoTipsAsync("adatok.txt");


//-Írjuk ki a képernyőre az össz adatot
lottoTipes.WriteCollectionToConsole();

//- Random számok segítségével generáljuk le a napi 7 nyerő számot és írjuk őket egy szöveges állományba melynek az aktuális nap lesz a neve
List<int> dailyWinnerNumbers = await Dataprocessing.GetDailyWinnerNumbersAsync(7) ;
await FileService.WriteToFileAsync(dailyWinnerNumbers, $"{DateTime.Now.DayOfWeek}");

//- Keressük ki, van(ak)-e 7 találatos szelvény(ek), ha igen írjuk ki a nyertesek nevét a nyertesek-{mai dátum}.txt állományba.
await Dataprocessing.GetDailyWinnersAsync(lottoTipes, dailyWinnerNumbers);
List<string> winners = lottoTipes.Where(x => x.CorrectTips == 7).Select(x => x.TippersName).ToList();
await  FileService.WriteToFileAsync(winners, $"nyertesek-{DateTime.Now.Month}.{DateTime.Now.Day}");


//-Keressük ki, hogy a befizetett játékosok hány találatot értek el, és mentsük el a talalatok-{mai dátum}.txt állományba a játékos nevét és a találatainak számát
List<PlayersAndHits> playerNamesAndTheirScores = lottoTipes.Select(x => new PlayersAndHits
                                                            {
                                                                TippersName = x.TippersName,
                                                                CorrectTips = x.CorrectTips
                                                            }).ToList();
await FileService.WriteToFileAsync(playerNamesAndTheirScores, $"találatok-{DateTime.Now.Month}.{DateTime.Now.Day}");
