using ConstellationOfDelicacies.Bll;
using ConstellationOfDelicacies.Bll.Clients;
using ConstellationOfDelicacies.Bll.Models;
using ConstellationOfDelicacies.Bll.Models.InputModels;
using ConstellationOfDelicacies.Dal;
using ConstellationOfDelicacies.Dal.Dtos;
using ConstellationOfDelicacies.Dal.Repositories;
using System.Linq;

Context context = SingletoneStorage.GetStorage().Storage;

ProfileRepository profileRepository = new ProfileRepository();
ProfileClient profileClient = new ProfileClient();
SpecializationClient specializationClient = new SpecializationClient();

var a = specializationClient.GetSpTitleById(2);

Console.WriteLine();
