using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class DbInit
    {
        public void Init(ApplicationContext context)
        {
            if (!context.Authors.Any())
            {
                context.Authors.AddRange(new Author[]
                {
                    new Author { Name = "Jess Kidd" },
                    new Author { Name = "Martha McPhee" },
                    new Author { Name = "Megan Miranda" },
                    new Author { Name = "Helen Phillips" },
                    new Author { Name = "Karen Kingsbury" },
                    new Author { Name = "Stephen King" },
                    new Author { Name = "George Orwell" },
                    new Author { Name = "Jane Austen" },
                    new Author { Name = "Mark Twain" },
                    new Author { Name = "Ernest Hemingway" },
                    new Author { Name = "Agatha Christie" },
                    new Author { Name = "J.K. Rowling" },
                    new Author { Name = "F. Scott Fitzgerald" },
                    new Author { Name = "Charles Dickens" },
                    new Author { Name = "Leo Tolstoy" }
                });
                context.SaveChanges();
            }
            if (!context.Categories.Any())
            {
                context.Categories.AddRange(
                    new Category
                    {
                        Name = "Artistic",
                        Description = "The specificity of fiction is revealed by comparing it with art forms that use other material instead of verbal and linguistic material."
                    },
                    new Category
                    {
                        Name = "Adventure",
                        Description = "The genre is close to action movies, but unlike the latter, in adventure films, the emphasis is shifted from wit of the characters, the ability to outsmart or deceive the villain."
                    },
                    new Category
                    {
                        Name = "Science Fiction",
                        Description = "A genre that explores futuristic concepts, advanced science and technology, space exploration, time travel, and extraterrestrial life."
                    },
                    new Category
                    {
                        Name = "Fantasy",
                        Description = "A genre of speculative fiction set in a fictional universe, often inspired by mythology and folklore, with magical elements."
                    },
                    new Category
                    {
                        Name = "Mystery",
                        Description = "A genre focused on solving a crime, unraveling secrets, or uncovering hidden truths."
                    },
                    new Category
                    {
                        Name = "Romance",
                        Description = "A genre centered around love stories, relationships, and emotional bonds between characters."
                    },
                    new Category
                    {
                        Name = "Horror",
                        Description = "A genre intended to create feelings of fear, dread, and shock through suspense, violence, or supernatural elements."
                    },
                    new Category
                    {
                        Name = "Historical",
                        Description = "A genre that reconstructs past events and periods, often blending fictional characters with real historical figures."
                    },
                    new Category
                    {
                        Name = "Biography",
                        Description = "A detailed description or account of someone's life, including experiences, achievements, and struggles."
                    },
                    new Category
                    {
                        Name = "Poetry",
                        Description = "A literary form that uses rhythmic and aesthetic qualities of language to evoke meaning and emotions."
                    }
                );
                context.SaveChanges();
            }
            if (!context.Books.Any())
            {

                var books = new List<Book>
                {
                    new Book {
                            Title = "The Only Survivors",
                            Description = "Thrilling mystery about a group of former classmates who reunite to mark the tenth anniversary of a tragic accident.",
                            Price = 59,
                            PublishedOn = new DateTime(2021, 7, 24),
                            Publisher = "Novel Group Company",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Adventure"),
                            Authors = new List<Author>()
                            {
                            context.Authors.FirstOrDefault(e=>e.Name.Equals("Megan Miranda")),
                            context.Authors.FirstOrDefault(e=>e.Name.Equals("Helen Phillips"))
                            }
                        },
                        new Book {
                            Title = "The Night Ship",
                            Description = "Based on a real-life event, an epic historical novel from the award-winning author of Things in Jars.",
                            Price = 70,
                            PublishedOn = new DateTime(2022, 9, 12),
                            Publisher = "Jess Kidd",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Artistic"),
                            Authors = new List<Author>()
                            {
                            context.Authors.FirstOrDefault(e => e.Name.Equals("Jess Kidd"))
                            }
                        },
                        new Book {
                            Title = "Echoes of Eternity",
                            Description = "A sweeping fantasy saga with battles, love, and betrayal.",
                            Price = 45,
                            PublishedOn = new DateTime(2019, 3, 15),
                            Publisher = "Fiction House",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Fantasy"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Karen Kingsbury"))
                            }
                        },
                        new Book {
                            Title = "The Silent Lake",
                            Description = "A chilling mystery set around a remote lake house.",
                            Price = 52,
                            PublishedOn = new DateTime(2020, 5, 11),
                            Publisher = "Thriller Press",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Mystery"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Helen Phillips"))
                            }
                        },
                        new Book {
                            Title = "Winds of Tomorrow",
                            Description = "Science fiction about humanity’s first interstellar voyage.",
                            Price = 64,
                            PublishedOn = new DateTime(2018, 11, 2),
                            Publisher = "Galaxy Publishers",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Science Fiction"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Martha McPhee"))
                            }
                        },
                        new Book {
                            Title = "Shadows and Light",
                            Description = "A poetic exploration of life’s contradictions.",
                            Price = 30,
                            PublishedOn = new DateTime(2017, 8, 5),
                            Publisher = "Poetry World",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Poetry"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Jess Kidd"))
                            }
                        },
                        new Book {
                            Title = "Hearts in Storm",
                            Description = "An emotional romance novel about forbidden love.",
                            Price = 39,
                            PublishedOn = new DateTime(2016, 6, 19),
                            Publisher = "Love Stories Ltd.",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Romance"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Karen Kingsbury"))
                            }
                        },
                        new Book {
                            Title = "The Forgotten Empire",
                            Description = "Historical fiction about the rise and fall of a forgotten dynasty.",
                            Price = 78,
                            PublishedOn = new DateTime(2015, 4, 22),
                            Publisher = "History House",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Historical"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Megan Miranda"))
                            }
                        },
                        new Book {
                            Title = "Voices in the Dark",
                            Description = "A horror tale where voices whisper from beyond.",
                            Price = 41,
                            PublishedOn = new DateTime(2019, 10, 31),
                            Publisher = "Dark Tales",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Horror"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Helen Phillips"))
                            }
                        },
                        new Book {
                            Title = "The Painter’s Secret",
                            Description = "A biography of a reclusive painter whose art shook the world.",
                            Price = 55,
                            PublishedOn = new DateTime(2020, 1, 20),
                            Publisher = "Life Stories",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Biography"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Martha McPhee"))
                            }
                        },
                        new Book {
                            Title = "Dreamcatcher’s Oath",
                            Description = "Fantasy adventure across a magical realm.",
                            Price = 62,
                            PublishedOn = new DateTime(2018, 2, 14),
                            Publisher = "Fantasy World",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Fantasy"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Jess Kidd"))
                            }
                        },
                        new Book {
                            Title = "Secrets of the Old Manor",
                            Description = "Mystery novel with hidden passages and dark family secrets.",
                            Price = 48,
                            PublishedOn = new DateTime(2021, 9, 9),
                            Publisher = "Detective Press",
                            Category = context.Categories.FirstOrDefault(e => e.Name == "Mystery"),
                            Authors = new List<Author> {
                                context.Authors.FirstOrDefault(e => e.Name.Equals("Karen Kingsbury"))
                            }
                        },
                        new Book { Title="Lost Horizons", Description="Adventure across uncharted lands.", Price=60, PublishedOn=new DateTime(2014,7,12), Publisher="Explorer Press", Category=context.Categories.FirstOrDefault(e=>e.Name=="Adventure"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Jess Kidd")}
                        },
                        new Book { Title="Stars Beyond", Description="Sci-fi about colonizing Mars.", Price=65, PublishedOn=new DateTime(2019,1,1), Publisher="Space Future", Category=context.Categories.FirstOrDefault(e=>e.Name=="Science Fiction"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Megan Miranda")}
                        },
                        new Book { Title="Broken Chains", Description="Historical drama of revolution.", Price=50, PublishedOn=new DateTime(2015,5,9), Publisher="History Ink", Category=context.Categories.FirstOrDefault(e=>e.Name=="Historical"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Helen Phillips")}
                        },
                        new Book { Title="Crimson Moon", Description="Supernatural horror.", Price=42, PublishedOn=new DateTime(2022,3,3), Publisher="Horror House", Category=context.Categories.FirstOrDefault(e=>e.Name=="Horror"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Martha McPhee")}
                        },
                        new Book { Title="Endless Love", Description="Classic romance story.", Price=38, PublishedOn=new DateTime(2017,2,14), Publisher="LoveBooks", Category=context.Categories.FirstOrDefault(e=>e.Name=="Romance"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Karen Kingsbury")}
                        },
                        new Book { Title="Whispers of Time", Description="Poetry on fleeting life.", Price=28, PublishedOn=new DateTime(2016,12,1), Publisher="Poetry Club", Category=context.Categories.FirstOrDefault(e=>e.Name=="Poetry"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Jess Kidd")}
                        },
                        new Book { Title="The Iron Throne", Description="Epic fantasy kingdom struggles.", Price=80, PublishedOn=new DateTime(2020,5,30), Publisher="Epic Tales", Category=context.Categories.FirstOrDefault(e=>e.Name=="Fantasy"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Megan Miranda")}
                        },
                        new Book { Title="Last Witness", Description="Crime mystery of lost evidence.", Price=47, PublishedOn=new DateTime(2018,6,21), Publisher="Detective House", Category=context.Categories.FirstOrDefault(e=>e.Name=="Mystery"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Helen Phillips")}
                        },
                        new Book { Title="Ocean’s Breath", Description="Adventure in deep sea.", Price=54, PublishedOn=new DateTime(2019,9,14), Publisher="Marine House", Category=context.Categories.FirstOrDefault(e=>e.Name=="Adventure"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Martha McPhee")}
                        },
                        new Book { Title="Future Tides", Description="Sci-fi thriller on AI control.", Price=68, PublishedOn=new DateTime(2021,1,25), Publisher="TechWorld Books", Category=context.Categories.FirstOrDefault(e=>e.Name=="Science Fiction"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Karen Kingsbury")}
                        },
                        new Book { Title="Voices of the Past", Description="Biography of unsung heroes.", Price=56, PublishedOn=new DateTime(2017,8,8), Publisher="LifeStories", Category=context.Categories.FirstOrDefault(e=>e.Name=="Biography"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Jess Kidd")}
                        },
                        new Book { Title="Fearless Nights", Description="Horror stories in small town.", Price=43, PublishedOn=new DateTime(2022,10,10), Publisher="DarkMoon", Category=context.Categories.FirstOrDefault(e=>e.Name=="Horror"), Authors=new List<Author>{ context.Authors.FirstOrDefault(e=>e.Name=="Megan Miranda")}
                        }
                };
                context.Books.AddRange(books);

                context.SaveChanges();
            }
            if (!context.Promotions.Any())
            {
                context.Promotions.AddRange(
                    new Promotion
                    {
                        Name = "Spring Sale!",
                        Percent = 10,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("Echoes of Eternity"))
                    },
                    new Promotion
                    {
                        Name = "Weekend Deal!",
                        Amount = 20,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("The Silent Lake"))
                    },
                    new Promotion
                    {
                        Name = "Summer Reads Discount",
                        Percent = 12,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("Winds of Tomorrow"))
                    },
                    new Promotion
                    {
                        Name = "Poetry Month Offer",
                        Amount = 8,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("Shadows and Light"))
                    },
                    new Promotion
                    {
                        Name = "Romance Week!",
                        Percent = 18,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("Hearts in Storm"))
                    },
                    new Promotion
                    {
                        Name = "Historical Flash Sale",
                        Amount = 15,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("The Forgotten Empire"))
                    },
                    new Promotion
                    {
                        Name = "Horror Night Special",
                        Percent = 20,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("Voices in the Dark"))
                    },
                    new Promotion
                    {
                        Name = "Biography Spotlight",
                        Amount = 10,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("The Painter’s Secret"))
                    },
                    new Promotion
                    {
                        Name = "Fantasy Frenzy!",
                        Percent = 25,
                        Book = context.Books.FirstOrDefault(e => e.Title.Equals("The Iron Throne"))
                    },
                    new Promotion
                {
                    Name = "Sci-Fi Sunday",
                    Amount = 18,
                    Book = context.Books.FirstOrDefault(e => e.Title.Equals("Future Tides"))
                }
                );
                context.SaveChanges();
            }
            if (!context.Reviews.Any())
            {
                context.Reviews.AddRange(
                    new Review { UserName = "Lena", UserEmail = "lena@mail.com", Comment = "Захватывающий сюжет!", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Echoes of Eternity") },
                    new Review { UserName = "Tom", UserEmail = "tom@mail.com", Comment = "Местами затянуто, но концовка отличная.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "Echoes of Eternity") },

                    new Review { UserName = "Nina", UserEmail = "nina@mail.com", Comment = "Очень атмосферно, читается легко.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "The Silent Lake") },

                    new Review { UserName = "Igor", UserEmail = "igor@mail.com", Comment = "Интересная идея, но реализация слабовата.", Stars = 3, Book = context.Books.FirstOrDefault(e => e.Title == "Winds of Tomorrow") },

                    new Review { UserName = "Sara", UserEmail = "sara@mail.com", Comment = "Поэтично и глубоко.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Shadows and Light") },
                    new Review { UserName = "Max", UserEmail = "max@mail.com", Comment = "Не все стихи зашли, но есть сильные моменты.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "Shadows and Light") },

                    new Review { UserName = "Olga", UserEmail = "olga@mail.com", Comment = "Очень трогательная история.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Hearts in Storm") },

                    new Review { UserName = "Dmitry", UserEmail = "dmitry@mail.com", Comment = "Историческая часть хорошо раскрыта.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "The Forgotten Empire") },

                    new Review { UserName = "Eva", UserEmail = "eva@mail.com", Comment = "Настоящий ужас! В хорошем смысле.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Voices in the Dark") },

                    new Review { UserName = "Leo", UserEmail = "leo@mail.com", Comment = "Интересная биография, много нового узнал.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "The Painter’s Secret") },

                    new Review { UserName = "Anna", UserEmail = "anna@mail.com", Comment = "Классическая фэнтези, но с изюминкой.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Dreamcatcher’s Oath") },

                    new Review { UserName = "Victor", UserEmail = "victor@mail.com", Comment = "Местами предсказуемо, но всё равно интересно.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "Secrets of the Old Manor") },

                    new Review { UserName = "Kate", UserEmail = "kate@mail.com", Comment = "Настоящее приключение!", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Lost Horizons") },

                    new Review { UserName = "Roman", UserEmail = "roman@mail.com", Comment = "Научная фантастика с хорошей динамикой.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "Stars Beyond") },

                    new Review { UserName = "Mila", UserEmail = "mila@mail.com", Comment = "История революции показана ярко.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Broken Chains") },

                    new Review { UserName = "Denis", UserEmail = "denis@mail.com", Comment = "Жутко и атмосферно.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Crimson Moon") },

                    new Review { UserName = "Tanya", UserEmail = "tanya@mail.com", Comment = "Романтика как в старых фильмах.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "Endless Love") },

                    new Review { UserName = "Sergey", UserEmail = "sergey@mail.com", Comment = "Очень трогательные стихи.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Whispers of Time") },

                    new Review { UserName = "Natalie", UserEmail = "natalie@mail.com", Comment = "Фэнтези на уровне, рекомендую.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "The Iron Throne") },

                    new Review { UserName = "George", UserEmail = "george@mail.com", Comment = "Детектив с неожиданным финалом.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Last Witness") },

                    new Review { UserName = "Inna", UserEmail = "inna@mail.com", Comment = "Морская тема раскрыта отлично.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "Ocean’s Breath") },

                    new Review { UserName = "Yuri", UserEmail = "yuri@mail.com", Comment = "AI и будущее — актуально и страшно.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Future Tides") },

                    new Review { UserName = "Elena", UserEmail = "elena@mail.com", Comment = "Герои, о которых стоит помнить.", Stars = 5, Book = context.Books.FirstOrDefault(e => e.Title == "Voices of the Past") },

                    new Review { UserName = "Andrey", UserEmail = "andrey@mail.com", Comment = "Маленький город, большие страхи.", Stars = 4, Book = context.Books.FirstOrDefault(e => e.Title == "Fearless Nights") }
                );
                context.SaveChanges();
            }
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(
                    new Order
                    {
                        CustomerName = "Ivan",
                        City = "Lviv",
                        Address = "Franko 22, kv 5",
                        Shipped = true,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Echoes of Eternity") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Olga",
                        City = "Odessa",
                        Address = "Deribasovskaya 14, kv 2",
                        Shipped = false,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 2, Book = context.Books.FirstOrDefault(e => e.Title == "The Silent Lake") },
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Winds of Tomorrow") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Dmitry",
                        City = "Kharkiv",
                        Address = "Gagarina 88, kv 11",
                        Shipped = true,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Shadows and Light") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Natalia",
                        City = "Zaporizhzhia",
                        Address = "Sobornyi 45, kv 9",
                        Shipped = false,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Hearts in Storm") },
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "The Forgotten Empire") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Sergey",
                        City = "Vinnytsia",
                        Address = "Pushkina 3, kv 6",
                        Shipped = true,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 3, Book = context.Books.FirstOrDefault(e => e.Title == "Voices in the Dark") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Anna",
                        City = "Chernihiv",
                        Address = "Kotsyubynskoho 19, kv 4",
                        Shipped = false,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "The Painter’s Secret") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Yaroslav",
                        City = "Poltava",
                        Address = "Petrovskogo 77, kv 12",
                        Shipped = true,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 2, Book = context.Books.FirstOrDefault(e => e.Title == "Dreamcatcher’s Oath") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Elena",
                        City = "Rivne",
                        Address = "Volodymyrska 5, kv 1",
                        Shipped = false,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Secrets of the Old Manor") },
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Lost Horizons") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Andriy",
                        City = "Ternopil",
                        Address = "Bandery 10, kv 8",
                        Shipped = true,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Stars Beyond") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Sofia",
                        City = "Zhytomyr",
                        Address = "Lesi Ukrainky 33, kv 14",
                        Shipped = false,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 2, Book = context.Books.FirstOrDefault(e => e.Title == "Broken Chains") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Roman",
                        City = "Uzhhorod",
                        Address = "Korzo 18, kv 7",
                        Shipped = true,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Crimson Moon") },
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Endless Love") }
                        }
                    },
                    new Order
                    {
                        CustomerName = "Irina",
                        City = "Ivano-Frankivsk",
                        Address = "Nezalezhnosti 21, kv 3",
                        Shipped = false,
                        Lines = new List<OrderLine> {
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "Whispers of Time") },
                            new OrderLine { Quantity = 1, Book = context.Books.FirstOrDefault(e => e.Title == "The Iron Throne") }
                        }
                    }
                );
                context.SaveChanges();
            }


        }

    }
}
