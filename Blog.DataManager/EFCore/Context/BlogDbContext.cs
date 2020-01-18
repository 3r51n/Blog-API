﻿using System;
using Blog.Common;
using Blog.Model;
using Blog.Model.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Blog.DataManager.EFCore.Context
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext() : base(new DbContextOptions<BlogDbContext>())
        { }
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Reference> References { get; set; }
        public DbSet<SocialPlatform> SocialPlatforms { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<AuthorInterestMapping> AuthorInterestMappings { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Server=.;Database=yeniblog;Trusted_Connection=True;MultipleActiveResultSets=True;Integrated Security=true")
                    .ConfigureWarnings(x => x.Ignore(RelationalEventId.AmbientTransactionWarning));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [ Default Entities ]

            var _author = new Author
            {
                Key = Guid.NewGuid(),
                Password = HashOperation.GetHashValue("administrator"),
                Username = "isleyen",
                EmailAddress = "husnuisleyen@gmail.com",
                FirstName = "Hüsnü",
                LastName = "İşleyen",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                City = "Burdur/Türkiye",
                Job = "Yazılım Geliştirici",
                Active = true
            };
            modelBuilder
                .Entity<Author>()
                .HasData(_author);

            #region [ Social Platforms ]
            var _google = new SocialPlatform()
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                Name = "google",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AccountUrl = "mailto:husnuisleyen@gmail.com",
                Logo = "data:image/png;base64,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"
            };

            var _medium = new SocialPlatform()
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                Name = "medium",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AccountUrl = "https://medium.com/@husnuisleyen",
                Logo = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADAAAAAwCAYAAABXAvmHAAAABmJLR0QA/wD/AP+gvaeTAAAC7UlEQVRoge2YW0gUURzGv9UV1PKKuhldNHNFLTWoTPKCmautrpcyqqeeepFIyB6sSBa1y0MQlQ/hUz2kVlqud42MVkxNokwsNLdUyoq8a27QbvY2dppZa3YODsH5Pe35/nPO9/9mOMyZBRgMBkNOFLYK0SmZiyvZyN/objEI9uqw0o3QhgWQGxZAblgAuVGKnVBZVoqADesEazdu3cbNinvLzlcoFKgsu46N6/lrDAyZcPR4vqh+RD+Bk4XFmJ6ZFazl6LRwUi5/T7ZHRQg2P2h6jxNn9GLbER9g7PMXnLt4WbDm4+2FpPjdy84/kJ4qqOed1WNmdk5sO/btgZ6Xr2zWjuzPsFlT+fogbtdOwdrU9Iw9rUjfxFarlRiHbA5C1JYwwWuztBo4OjpKtSSQHKCt/SlPO5yt42lOSiUyUzVS7XhIDlBxv5anxcdEY+0aFaElxsbA28sTpuERqZYEkgO8HnyL3v435KIODjiYkUZoOTotAKC6rkmqJelFY5GKagNPy9yXjNWrXAEAwZsCEBEeigWzGS2PjTQsOagEMHZ248PYJ0JzdXFBuiYJwNLdb2htw7eFBRqWHFQC/FxcxB1DPU8/lKWDh7sbNInxAICaphYadgTUzkL1rY8wNz9PaP4qP5ScPgUXZ2c87+2DaXiUlh0HtQBm83fUNLby9B3bIgEAVXWNtKwIqJ5G7xoa8MNi4enjk1No73pG04qDaoCvExNoM3bw9AcNzbBYrAIzpGNXAJWvD/fbX+VH1Mr/eLFZLFYYmh/aY/NPiA7gpFSiqGDpzF5UkE8coQeGTHjR18+Nn3R2YXxikhuHqYMF1/Xy9BDbCgB7vgdyjyEyPJQbbw0NQUFeLnFN+W8vtqrapc2rDgrElZJCwXWvntfDw91NbDviAuxNiEW2NoWnpyXvQXJCHDfu6O7B6McxvBsZ5Z6Gv8oPpZeKbTapDgrEtQt6Me0AYH8tyg8LIDcsgNywAHLz3wdgMBgMefkF7azAa6f2ACMAAAAASUVORK5CYII="
            };

            var _facebook = new SocialPlatform()
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                Name = "facebook",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AccountUrl = "https://www.facebook.com/isleyenhusnu",
                Logo = "data:image/png;base64,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"
            };

            var _twitter = new SocialPlatform()
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                Name = "twitter",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AccountUrl = "https://twitter.com/_slyn",
                Logo = "data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAADIAAAAyCAYAAAAeP4ixAAAABmJLR0QA/wD/AP+gvaeTAAAHtklEQVRoge2ZaWyU1xWGn/PN5uIFZmyDxwZMCWZNIjbTELEnYQmQQhvRlKg0VUMgbVUpJCEkCEIaFCWkDVEqobJI0FAiSiVQNpYAoTgViGACQUCARAQc22NsjxdswPbMfKc/DM4YZr5ZTNQf9SuNRjr33Peed+49dzkDnehEJ/4vIP/rAGKhbn/ucEN1QkjlgPuh8uPR/O64ENUVhs8/uj+YgxTJwzBTATCNq4KWgfGVN/PweZEVphVP/V7vx2rIMlE9AthBAqYpo9yTy078YEJUix3l/uqHRfRxYBKQGaOLX2E/Jltys7J3iYwMRHK6si/nWUX+HBbssxkP+t6K5NshIad1m7ObP22BiDwP9EqORUtUjTdzM7PW3iqodm/uMEM4AuoACZiGFLonlX0ZiSVpIeU1u8eirAUdlCzHLTiDsCDXM+0/4cbaT/KGGmJONG3Gp9FEQBJCVFV8/l0vIfIKYEsiYCsEUZZ7M6e+LiKaSMeEhKhus/lq0tcCv00ovMSxwetpWCgyJ3TTsGr75BkmugXVuUt+vu/jWzsY8TKrqvhq0v/GDy8C4ElfbfpGVW37oU01tfU78kzFPSPl1TuXIrIy3NbSHOBY0UkqfA2Ymly6GaJ4czMYNuZuXCnOW6N7Mdcz7fV4eOIavTWx9QBhOVHyjY91b+3EVjAJe04BYrMnEP730FCQYMU5mk/t4XdLZtO7wBveHFSM8XmZUw7F4okp5LRuc7prMk6E704tzQH+9My7ZMxeCSKEzhXhCDYkJMCe0oUfT/gpddeh+qpJ8NoVGncsY/nb83A4HeGuZ7ye7KHRzpo2vlgDdvOnLUDab7HHik5iK5gEIqQe3cgfn3mCrB7dExISjsOXguw4nYH0m0hx0SlGPzgMgKyu99N4/cLgitqK+cAaKw7LZFctdtw47Nqh7Lt67DkFhM4VdVgEwOh8O1mpBg5vf0pL6trsjdcvEAjWocpi1WKHBYW1EJ+/cjoRTuxgSBGbHblW02ERN+FqrkNsdkKh769gTS0VhMwmgPzLtf4pVv2tZ0Tkl3ckSsA0Q7Q0t0Rtv1j0gXV/NedatUfNEdUVhq+GSbECDMf7//qIqTMfwpXiamdfu+Y9DhRfJGjrQr9M6JPnpqayipdefa7Np8+4R/jmUoUV/WTVFUa0W3NUIT7/yAEIWYkI2bzjc/792UmWL1+IO8sDwGcHj/DPs6n47lkKwNnmWnocWk9O/XEarzSQlpEOQPX5E+DKsaLPLK/+SQFwLiEhYBuYiAgAI7MXe3MepWrZJu4r6MqMR8azb//nVPRe2OYTcrmx9b2PP8ya2SYCoLGiBPIthQAMIFEhivaUBO+U2Q1f4cis51j/RXzZWM6udw5iawig97Y/sfONckYXjm1ny+h5FzUx+A2RqE+FqEIEIx0Uh70bDnsG15tLUbV81FFpeLFrEwDBtFwupEXeK7o6b78udfH0oKY+aMmvaEa0tpiXRk/6CLp2GcyPXD1juTJz+mgIhaydzCB9PLfPdMXJmLcQS0QVonAFoDlQjaktBIL1MckemzGKPsdWkeI/H9VngH8vc342IYlQQZAr0doslpaWAdQ1Rn2U3Qany8mUeb/Bd7qBJg2BtH93uZoqmZp/le7eHnFzhsNU/S5am8XSCp1NZJCW5mZ8pWWMHuhhRNV2ssoOtmtPaSxltvkRT82flQjtrYi4Y4HFjGSV/CP1qnvE1YArNzXo8sQcofRSKS8/v5LLaYMpv/s5QiluRE1c9d/S7+oRZg7N4FePP4FI0mWCytysqVHXbEQhLcW/GC4qh9NqvrAjJ6j1TifodFuO0rf/XWx+fyNHj57m4KE9NFxroWt6CveO7c2E8Y9id1je+eLBfqt3fEQhgjGxrU1NHE2+mEJuorBwCIWFQ5KI0xoissWqPWKOqOqnQOAGgwZS2p+4dpugoSDaxUP15coOB1lVUQmpmWgoiM0WMaRLOW7XHiuOiL2chVuPqyGjFF1Unz32jaCzfY707N2NYMU5bAPH887qTa2BdEDEX9/ehDFgHAHfeXrl3z7zIvqGyETL0zJm5qkesPtqmr4A7rlpa25q4eXfb8D92CrEsBE6exCt9yWjA6NbLsaAcagZom7rYl5ZMx+nq10+nfZ6sofFeurGWXzYNQblAGE5VfK1j/WrdyL9JuLw9u9Q8SFQfo7AmU94esms24oPJozrmTntcCyeBMpBu15EeC3cFmgJUFx0ipJv/QRarO9J0eBw2snvm8XwMUNunQlU5IU8z9RV8fDELaS1QLd7HfBkYqEmC1nf/eLmDxRzi6jOtY/celt1MRxxVxpFRL2ehoXAhg7HGHu09V7PlafRUOu5oUbMOnByReza3S+gvEoc5aQEEVSRpfEup3AkfV8o8++5XzDXAXfo9NNTJvJUPIkdCR36o0e12FFRWzVflcVAfpI0l0T0jRx39w2xtlgrJCTkte0PZAq2ea6g/H3RnD1tL1PVYkd5beVUQ2WuKg8gZFsSKVUI+wwx3uvhdu6OddjFg4TWuIHxa9C/NLf2Wn3TfuOX/BD4UFWlrHpngYhtkGFonommt/aVBjNEqWKezct6+OtE/8iJhYSEOIPGpoAtZDpDxrvRfG4EeP7GpxOd6EQn7iz+C7l/5wgHGEdgAAAAAElFTkSuQmCC"
            };

            var _instagram = new SocialPlatform()
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                Name = "instagram",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AccountUrl = "https://www.instagram.com/husnuisleyen/",
                Logo = "data:image/png;base64,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"
            };

            var _linkedin = new SocialPlatform()
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                Name = "linkedin",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AccountUrl = "https://www.linkedin.com/in/hüsnü-işleyen-29468475",
                Logo = "data:image/png;base64,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"
            };

            var _github = new SocialPlatform()
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                Name = "github",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AccountUrl = "https://github.com/slyn",
                Logo = "data:image/png;base64,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"
            }; 
            #endregion
            modelBuilder
                .Entity<SocialPlatform>()
                .HasData(_github,_twitter,_google,_medium,_linkedin,_facebook,_instagram);

            #region [ Companies ]

            var _comp1 = new Company
            {
                Key = Guid.NewGuid(),
                Name = "Bereket Enerji Üretim A.Ş.",
                Location = "Denizli/Türkiye",
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                LogoUrl = "https://via.placeholder.com/250"
            };
            var _comp2 = new Company
            {
                Key = Guid.NewGuid(),
                Name = "Netinternet",
                Location = "Denizli/Türkiye",
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                LogoUrl = "https://via.placeholder.com/250"
            };
            #endregion
            modelBuilder
                .Entity<Company>()
                .HasData(_comp1, _comp2);

            #region [ Experiences ]
            var _xp1 = new Experience
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                CompanyKey = _comp2.Key,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Begin = DateTime.UtcNow,
                Position = "Stajyer",
                End = DateTime.UtcNow
            };
            var _xp2 = new Experience
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                CompanyKey = _comp2.Key,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Begin = DateTime.UtcNow,
                Position = "Stajyer",
                End = DateTime.UtcNow
            };
            var _xp3 = new Experience
            {
                AuthorKey = _author.Key,
                Active = true,
                Key = Guid.NewGuid(),
                CompanyKey = _comp1.Key,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Begin = DateTime.UtcNow,
                Position = "Yazılım Geliştirme Uzm.Yrd.",
                End = DateTime.UtcNow
            };
            #endregion
            modelBuilder
                .Entity<Experience>()
                .HasData(_xp1,_xp2,_xp3);

            #region [ Universities ]
            var _uni1 = new University
            {
                Key = Guid.NewGuid(),
                Name = "Pamukkale Universitesi",
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Location = "Denizli/Türkiye",
                LogoUrl = "https://via.placeholder.com/250"
            };
            var _uni2 = new University
            {
                Key = Guid.NewGuid(),
                Name = "Silesian University of Technology",
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Location = "Gliwice/POLAND",
                LogoUrl = "https://via.placeholder.com/250"
            };
            #endregion
            modelBuilder
                .Entity<University>()
                .HasData(_uni1,_uni2);

            #region [ Educations ]

            var _edu1 = new Education
            {
                Active = true,
                Key = Guid.NewGuid(),
                AuthorKey = _author.Key,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                UniversityKey = _uni1.Key,
                Begin = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Department = "Mühendislik Fakültesi",
                Branch = "Bilgisayar Mühendisliği",
                Detail = "",
                Score = (float)3.46
            };
            var _edu2 = new Education
            {
                Active = true,
                Key = Guid.NewGuid(),
                AuthorKey = _author.Key,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                UniversityKey = _uni1.Key,
                Begin = DateTime.UtcNow,
                End = DateTime.UtcNow,
                Department = "Faculty of Automatic Control, Electronics and Computer Science",
                Branch = "Computer Science",
                Detail = "Erasmus+",
                Score = null
            };
            #endregion
            modelBuilder
                .Entity<Education>()
                .HasData(_edu1, _edu2);

            #region [ Ability & Interest ]

            var _interest1 = new Interest
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Name = "C#"
            };
            var _interest2 = new Interest
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Name = "Python"
            };
            var _interest3 = new Interest
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Name = "ASP.NET Core"
            };
            #endregion
            modelBuilder
                .Entity<Interest>()
                .HasData(_interest1, _interest2, _interest3);

            #region [ Author-Interest Mapping ]

            var _mapping1 = new AuthorInterestMapping
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AuthorKey = _author.Key,
                InterestKey = _interest1.Key
            };
            var _mapping2 = new AuthorInterestMapping
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AuthorKey = _author.Key,
                InterestKey = _interest2.Key
            };
            var _mapping3 = new AuthorInterestMapping
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AuthorKey = _author.Key,
                InterestKey = _interest3.Key
            };
            #endregion
            modelBuilder
                .Entity<AuthorInterestMapping>()
                .HasData(_mapping1, _mapping2, _mapping3);

            #region [ Success ]

            var _success1 = new Success
            {
                Key = Guid.NewGuid(),
                Active = true,
                Name = "Lisans Mezuniyet",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Date = new DateTime(2016,6,19),
                Detail = "3.46/4.0 - Bölüm İkinciliği",
                SuccessType = SuccessTypes.School,
                AuthorKey = _author.Key
            };
            var _success2 = new Success
            {
                Key = Guid.NewGuid(),
                Active = true,
                Name = "Lisans Tezi",
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                Date = new DateTime(2016, 5, 19),
                Detail = "UYGULAMA",
                SuccessType = SuccessTypes.Code,
                AuthorKey = _author.Key
            };
            #endregion
            modelBuilder
                .Entity<Success>()
                .HasData(_success1, _success2);

            #region [ References ]
            var _reference1 = new Reference()
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AuthorKey = _author.Key,
                FirstName = "Firstname",
                LastName = "Lastname",
                GSM = "[ SECRET ]",
                Position = "SOFTWARE DEVELOPER",
                AccountUrl = "https://visualgo.net/en",
                ImageUrl = "https://via.placeholder.com/250"
            };
            var _reference2 = new Reference()
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AuthorKey = _author.Key,
                FirstName = "Firstname2",
                LastName = "Lastname2",
                GSM = "[ SECRET ]",
                Position = "SOFTWARE DEVELOPER",
                AccountUrl = "https://visualgo.net/en",
                ImageUrl = "https://via.placeholder.com/250"
            };
            var _reference3 = new Reference()
            {
                Key = Guid.NewGuid(),
                Active = true,
                CreateDate = DateTime.UtcNow,
                LastUpdateDate = DateTime.UtcNow,
                AuthorKey = _author.Key,
                FirstName = "Firstname3",
                LastName = "Lastname3",
                GSM = "[ SECRET ]",
                Position = "SOFTWARE DEVELOPER",
                AccountUrl = "https://visualgo.net/en",
                ImageUrl = "https://via.placeholder.com/250"
            };
            #endregion
            modelBuilder
                .Entity<Reference>()
                .HasData(_reference1,_reference2, _reference3);
            #endregion

            //modelBuilder.RemovePluralizingTableNameConvention();
        }
    }
}
