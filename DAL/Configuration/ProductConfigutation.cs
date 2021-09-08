using GameCenter.DAL.Entities;
using GameCenter.DAL.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameCenter.DAL.Configuration
{
    public class ProductConfigutation : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasOne(x => x.Order).WithOne(x => x.Product).IsRequired();
            builder.Property(b => b.DateCreated).HasDefaultValueSql("getdate()").IsRequired();
            builder.HasData(
                new Product { Id = Guid.Parse("a76d6bde-c48c-4dcb-b80a-7c6edce28c74"), Name = "FIFA 2020", GameRating = 7.32, Genre = GameGenres.Simulator, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229539/ASP_Labs/FIFA_series_logo.svg_geizkx.png", Price = 10, CountProducts = 1090 },
                new Product { Id = Guid.Parse("7bad0c87-edd2-4a23-aade-aaff2e19f54f"), Name = "God of War", GameRating = 8.31, Genre = GameGenres.RPG, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229190/ASP_Labs/D0_9B_D0_BE_D0_B3_D0_BE_D1_82_D0_B8_D0_BF__D0_B8_D0_B3_D1_80_D1_8B_God_of_War_mgno9l.png", Price = 20, CountProducts = 1080 },
                new Product { Id = Guid.Parse("67550e04-f55d-40c6-bd72-3cbffef51317"), Name = "Bloodborne", GameRating = 6.81, Genre = GameGenres.Strategy, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229196/ASP_Labs/D0_9E_D0_B1_D0_BB_D0_BE_D0_B6_D0_BA_D0_B0_Bloodborne_zsqu5h.jpg", Price = 30, CountProducts = 1070 },
                new Product { Id = Guid.Parse("5acb3515-9b43-4b80-9338-1ff4e0dc972b"), Name = "Among Us", GameRating = 8.32, Genre = GameGenres.Simulator, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229203/ASP_Labs/Among_Us_y6hnjs.png", Price = 40, CountProducts = 1060 },
                new Product { Id = Guid.Parse("ea803243-ed41-49e9-9670-29619e3e4961"), Name = "Brawl Stars", GameRating = 10, Genre = GameGenres.MMO, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229211/ASP_Labs/Brawl_Stars_w86qfv.png", Price = 50, CountProducts = 1050 },
                new Product { Id = Guid.Parse("77133fcf-3da2-42d0-9b9d-32ec0dc5f421"), Name = "Fortnite", GameRating = 8.88, Genre = GameGenres.MMORPG, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229220/ASP_Labs/1920px-FortniteLogo.svg_kcwnbv.png", Price = 60, CountProducts = 1040 },
                new Product { Id = Guid.Parse("0e70d082-9558-48aa-84a8-5a34ac95af08"), Name = "Minecraft", GameRating = 9.51, Genre = GameGenres.Simulator, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229230/ASP_Labs/1920px-MinecraftLogo.svg_gamutf.png", Price = 70, CountProducts = 1030 },
                new Product { Id = Guid.Parse("50973345-c933-4098-9513-3c16d82dcc0a"), Name = "Forza Horizon 4", GameRating = 9.49, Genre = GameGenres.Simulator, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229084/ASP_Labs/Forza_Horizon_4_coverart_qmuz6l.jpg", Price = 80, CountProducts = 1020 },
                new Product { Id = Guid.Parse("cd4e1a11-ef0c-402c-a2ab-b18622ea1eb9"), Name = "Super Smash Bros. Ultimate", GameRating = 8.36, Genre = GameGenres.RPG, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229253/ASP_Labs/Super_Smash_Bros._Ultimate_yvp3wa.png", Price = 90, CountProducts = 1010 },
                new Product { Id = Guid.Parse("82e27206-1bfd-4d62-a6bf-be44ad030b25"), Name = "Super Mario Odyssey", GameRating = 8.43, Genre = GameGenres.Simulator, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229266/ASP_Labs/Super_Mario_Odyssey_box_ydaxqk.jpg", Price = 100, CountProducts = 100 },
                new Product { Id = Guid.Parse("a1c40a91-a1a4-4d9e-960d-b0c19b425c8c"), Name = "Animal Crossing", GameRating = 7.55, Genre = GameGenres.Strategy, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229280/ASP_Labs/Animal_Crossing_Logo_tbw4bw.png", Price = 110, CountProducts = 1600 },
                new Product { Id = Guid.Parse("1952c825-184a-40e9-8864-80358a9f1da6"), Name = "Dota 2", GameRating = 7.64, Genre = GameGenres.MMORPG, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229295/ASP_Labs/D0_9E_D0_B1_D0_BB_D0_BE_D0_B6_D0_BA_D0_B0_Dota_2_rd8cox.jpg", Price = 120, CountProducts = 1500 },
                new Product { Id = Guid.Parse("d4b797a8-2f74-446e-ad0c-71dad9e37e59"), Name = "CS GO", GameRating = 8.27, Genre = GameGenres.Strategy, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229311/ASP_Labs/1920px-_D0_9B_D0_BE_D0_B3_D0_BE_D1_82_D0_B8_D0_BF_Counter-Strike_Global_Offensive.svg_cg9fcb.png", Price = 130, CountProducts = 1400 },
                new Product { Id = Guid.Parse("c3279ca3-8fe4-45c9-8606-ae09f8b7f259"), Name = "Overwatch", GameRating = 7.72, Genre = GameGenres.MMO, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229328/ASP_Labs/Overwatch_cover_art_whuqso.jpg", Price = 140, CountProducts = 1300 },
                new Product { Id = Guid.Parse("00189d6e-ed62-482b-a4d9-335dfa68d58e"), Name = "Half-Life", GameRating = 6.98, Genre = GameGenres.RPG, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229345/ASP_Labs/HL2box_lhx2ag.jpg", Price = 150, CountProducts = 1200 },
                new Product { Id = Guid.Parse("1ad798c4-da8c-4e87-a020-9272e4e71d2b"), Name = "Portal 2", GameRating = 8.56, Genre = GameGenres.Simulator, Logo = @"https://res.cloudinary.com/dimmitriy33/image/upload/v1625229364/ASP_Labs/Portal_boxcover_ojqdry.jpg", Price = 160, CountProducts = 1100 }
            );
        }
    }
}
