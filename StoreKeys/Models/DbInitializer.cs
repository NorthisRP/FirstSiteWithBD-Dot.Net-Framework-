using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace StoreKeys.Models
{
    public class DbInitializer : DropCreateDatabaseAlways<KeyContext>
    {
        protected override void Seed(KeyContext context)
        {
            context.Keys.Add(new Key() { Name = "The Elder Scrools Online: Elsweyr", Price = 1195, Img = "/Content/Images/teso-elsweyr.jpg", Tag = "Action, RPG" });
            context.Keys.Add(new Key() { Name = "Fallout 4", Price = 700, Img = "/Content/Images/1453491502_fallout4-415.jpg", Tag = "Action, RPG" });
            context.Keys.Add(new Key() { Name = "Don't Starve Together", Price = 200, Img = "/Content/Images/1833-460x215.jpg", Tag = "Action, Survival" });
            context.Keys.Add(new Key() { Name = "Mass Effect 3", Price = 300, Img = "/Content/Images/mass-effect-3-cover.jpg", Tag = "Shooter, RPG" });
            context.Keys.Add(new Key() { Name = "Call of Duty: Black Ops IV", Price = 1500, Img = "/Content/Images/codbo4_cover_SquUcnG-460x215.jpg", Tag = "Action, Shooter" });
            context.Keys.Add(new Key() { Name = "Anno 1404", Price = 200, Img = "/Content/Images/anno.jpg", Tag = "RTS, Economic" });
            context.Keys.Add(new Key() { Name = "Tom Clancy’s Ghost Recon Breakpoint", Price = 1500, Img = "/Content/Images/ghostrecon.jpg", Tag = "Action, Shooter" });
            context.Keys.Add(new Key() { Name = "Battlefield 1", Price = 2000, Img = "/Content/Images/battlefield.jpg", Tag = "Action, Shooter" });
            context.Keys.Add(new Key() { Name = "The Wolf Among Us", Price = 300, Img = "/Content/Images/wolf.png", Tag = "Quest" });
            context.Keys.Add(new Key() { Name = "H1Z1", Price = 800, Img = "/Content/Images/h1z1.jpg", Tag = "Survival, Horror, Action" });

            context.Users.Add(new User() { Email = "philw732@gmail.com", Name = "Roman", Surname = "Petrov", Password = "450299" });
            base.Seed(context);
        }
    }
}