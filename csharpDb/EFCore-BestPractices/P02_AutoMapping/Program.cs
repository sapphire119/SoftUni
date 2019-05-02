using AutoMapper;
using AutoMapper.QueryableExtensions;
using Forum.App.ModelsDto;
using Forum.Data;
using Forum.Models;
using System.Linq;

namespace P02_AutoMapping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            First(); //DTO (Data Transfer Objects)
            Second(); //За какво се ползва DTO
            Third(); //AutoMapper използваме install-package AutoMapper (има го в Nuget GUI-a)
        }

        private static void Third()
        {
            Mapper.Initialize(config =>
                    config.CreateMap<Post, PostDetailsDto>()
                        .ForMember(dto => dto.AuthorUsername,
                            cfg =>
                                cfg.MapFrom(post => post.Author.Username)) 
                            //Конкретизираме от къде да ни напълни property-то AuthorUsername,чрез Automapper опциите (става за всичко)
                );

            var context = new ForumDbContext();

            var posts = context.Posts
                    .Where(p => p.Author.Username == "gosho")
                    .ProjectTo<PostDto>() //Така работи Project-to
                    .ToArray();
        }

        private static void Second()
        {
            //1. За Премахване на кръгова референция.
            //2. Да премахнем определни property-та(информация), които клиента не иска да види.
            //3. Като презаписваме информацията в Data Transfer Objects заемат по-малко памет (място) и се предават по-лесно по мрежата.
            //4. Можем да си строго типизираме SQL заявките, чрез някакво Auto-mapping library. 
        }

        private static void First()
        {
            //Един обект, който пренася данни от едно място на друго място.
            //Използва се за агрегиране и пренасяне на инфорамция от едно място на друго.
            //Във view-model-ите може да имаме методи и някаква друга функционалност и пр.
            //Във DTO-та се използват само за запазване на инфорамция (могат да имат и друга функционалност,но не е препоръчително).Те само държат някакви стойности.
            //Може да ги инстанцираме на ръка, може да ги конвертираме в някакъв друг тип обекти (от един къ друг.) 
            //Може и да ги конвертираме автоматично и чрез auto-mapper-a.
            //Можем да ги използваме да пренасяме данни от един тип към друг. (Сериализация и десериализация).
            //Гарантираме си, че ще работим с някакви строго типизирани неша.
            //Знаем какво подаваме и какво да очакваме.
        }
    }
}
