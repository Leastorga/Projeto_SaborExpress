using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SaborExpress.Migrations
{
    public partial class PopularSnacks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Snacks(Name, ShortDescription, LongDescription, Price, ImageUrl, ThumbnailImageUrl, IsFavoriteSnack, InStock, CategoryId )"+ "VALUES('Cheese Salad', 'Bread, hamburger, egg, ham, cheese and straw potatoes', 'Delicious hamburger bun with fried egg; top quality ham and cheese accompanied with straw potatoes.', 12.50,'http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg','http://www.macoratti.net/Imagens/lanches/cheesesalada1.jpg',0, 1, 1 )");

            migrationBuilder.Sql("INSERT INTO Snacks(Name, ShortDescription, LongDescription, Price, ImageUrl, ThumbnailImageUrl, IsFavoriteSnack, InStock, CategoryId )"+ "VALUES('Grilled ham and cheese', 'Bread, ham, mozzarella and tomato', 'Delicious warm French bread on the grill with ham and mozzarella well served with lovingly prepared tomatoes.', 8.00,'http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg','http://www.macoratti.net/Imagens/lanches/mistoquente4.jpg',0, 1, 1 )");

            migrationBuilder.Sql("INSERT INTO Snacks(Name, ShortDescription, LongDescription, Price, ImageUrl, ThumbnailImageUrl, IsFavoriteSnack, InStock, CategoryId )" + "VALUES('Cheese Burguer', 'Bread, hamburger, ham, mozzarella and straw potatoes','Special hamburger bun with our own prepared hamburger and ham and mozzarella; accompanies straw potatoes.', 11.00,'http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg','http://www.macoratti.net/Imagens/lanches/cheeseburger1.jpg',0, 1, 1 )");

            migrationBuilder.Sql("INSERT INTO Snacks(Name, ShortDescription, LongDescription, Price, ImageUrl, ThumbnailImageUrl, IsFavoriteSnack, InStock, CategoryId )" + "VALUES('Natural turkey breast snack','Wholegrain bread, white cheese, turkey breast, carrot, lettuce, yogurt','Natural wholemeal bread with white cheese, turkey breast and grated carrot with shredded lettuce and natural yogurt.', 15.00,'http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg','http://www.macoratti.net/Imagens/lanches/lanchenatural.jpg',1, 1, 2 )");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Snacks");
        }
    }
}
