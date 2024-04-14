namespace PeaksAndAdventures.Common
{
	public static class ErrorMessages
	{
		public const string RequireErrorMessage = "Полете {0} е задължително за попълване!";
		public const string StringLengthErrorMessage = "Полето {0} трябва да съдържа между {2} и {1} знака!";
		public const string StringMaximumLength = "Полето {0} не може да съдържа повече от {1} знака!";
		public const string MountainIsAlreadyExist = "Планината вече съществува!";
		public const string PeakIsAlreadyExist = "Върха вече съществува!";
		public const string LakeIsAlreadyExist = "Езерото вече съществува!";
		public const string WaterfallIsAlreadyExist = "Водопада вече съществува!";
		public const string HutIsAlreadyExist = "Хижата вече съществува!";
		public const string AgencyWithThisNameIsExist = "Туристическа агенция с това име вече съществува!";
		public const string RouteIsAlreadyExist = "Маршрутът вече съществува!";
		public const string ArticleWithTheSameName = "Плагиатството не се толерира!";
        public const string TourAgencyNotExist = "Туристическата агенция не съществува!";
        public const string FailAddRouteToMountainGuide =
	        "Неуспешно добавяне на маршрут към планинския водач. Моля, уверете се, че планинският водач и маршрутът съществуват.";
        public const string DurationFormatIsWrong = "Невалиден формат. Форматът трябва да бъде 'дни.часове:минути'.";
        public const string CantDeleteTourAgencyBecauseOfExpeditionParticipant = "Изтриването на експедицията е неуспешно, тъй като има участници в нея. Моля, уведомете или отпишете участниците преди да продължите.";
        public const string YouCanVoteOnlyOnce = "Вече сте гласували!";
        public const string YouHaveAlreadyMountaineerProfile = "Вече имате създаден профил на планински водач.";
        public const string YouHaveAlreadyAgencyProfile = "Вече имате създаден профил на туристическа агенция.";
	}
}
