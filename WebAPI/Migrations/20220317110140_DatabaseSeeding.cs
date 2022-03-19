using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class DatabaseSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*  migrationBuilder.Sql(@"

  DECLARE @UserID as INT
  --------------------------
  --Create User
  --------------------------
  IF not exists (select Id from Users where Username='demo')
  insert into Users(Username,Password, PasswordKey,LastUpdatedOn,LastUpdatedBy)
  select 'demo',
  0xA780DF7944038BC32722764DD1D9757C11A65B7854DD95A0D8B9614F7DE7C42B9E38A3D2E53FF2E2F0F95CF5C27B0E316EDB168665926468B9064759DBCB5ED4,
  0xF4B32A1350510677E59F0D450856A94A6CA3504E7C576CCF47E04087D703148B4F559FDE43E589A54BFACBDCF6E1563F0F2878CFF87345C6E8CB415F703BC3B6047E75532FF76C6322D41BC7968E46744D96A7F96815D31A48B6FCBADC3A5FF23AEF7D97BEC71641AC83AFA1D48705C95D1312EB5034E283A5E33FD33B464411,
  getdate(),
  0

  SET @UserID = (select id from Users where Username='demo')

  --------------------------
  --Seed Property Types
  --------------------------
  IF not exists (select name from PropertyTypes where Name='House')
  insert into PropertyTypes(Name,LastUpdatedOn,LastUpdatedBy)
  select 'House', GETDATE(),@UserID

  IF not exists (select name from PropertyTypes where Name='Apartment')
  insert into PropertyTypes(Name,LastUpdatedOn,LastUpdatedBy)
  select 'Apartment', GETDATE(),@UserID

  IF not exists (select name from PropertyTypes where Name='Duplex')
  insert into PropertyTypes(Name,LastUpdatedOn,LastUpdatedBy)
  select 'Duplex', GETDATE(),@UserID


  --------------------------
  --Seed Furnishing Types
  --------------------------
  IF not exists (select name from FurnishingTypes where Name='Fully')
  insert into FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
  select 'Fully', GETDATE(),@UserID

  IF not exists (select name from FurnishingTypes where Name='Semi')
  insert into FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
  select 'Semi', GETDATE(),@UserID

  IF not exists (select name from FurnishingTypes where Name='Unfurnished')
  insert into FurnishingTypes(Name, LastUpdatedOn, LastUpdatedBy)
  select 'Unfurnished', GETDATE(),@UserID

  --------------------------
  --Seed Cities
  --------------------------
  IF not exists (select top 1 id from Cities)
  Insert into Cities(Name,LastUpdatedBy,LastUpdatedOn,Country)
  select 'New York',@UserID,getdate(),'USA'
  union
  select 'Houston',@UserID,getdate(),'USA'
  union
  select 'Los Angeles',@UserID,getdate(),'USA'
  union
  select 'New Delhi',@UserID,getdate(),'India'
  union
  select 'Bangalore',@UserID,getdate(),'India'

  --------------------------
  --Seed Properties
  --------------------------
  --Seed property for sell
  IF not exists (select top 1 name from Properties where Name='White House Demo')
  insert into Properties(SellRent,Name,PropertyTypeId,BHK,FurnishingTypeId,Price,BuiltArea,CarpetArea,Address,
  Address2,CityId,FloorNo,TotalFloors,ReadyToMove,MainEntrance,Security,Gated,Maintenance,EstPossessionOn,Age,Description,PostedOn,PostedBy,LastUpdatedOn,LastUpdatedBy)
  select 
  1, --Sell Rent
  'White House Demo', --Name
  (select Id from PropertyTypes where Name='Apartment'), --Property Type ID
  2, --BHK
  (select Id from FurnishingTypes where Name='Fully'), --Furnishing Type ID
  1800, --Price
  1400, --Built Area
  900, --Carpet Area
  '6 Street', --Address
  'Golf Course Road', -- Address2
  (select top 1 Id from Cities), -- City ID
  3, -- Floor No
  3, --Total Floors
  1, --Ready to Move
  'East', --Main Entrance
  0, --Security
  1, --Gated
  300, -- Maintenance
  '2019-01-01', -- Establishment or Posession on
  0, --Age
  'Well Maintained builder floor available for rent at prime location. # property features- - 5 mins away from metro station - Gated community - 24*7 security. # property includes- - Big rooms (Cross ventilation & proper sunlight) - 
  Drawing and dining area - Washrooms - Balcony - Modular kitchen - Near gym, market, temple and park - Easy commuting to major destination. Feel free to call With Query.', --Description
  GETDATE(), --Posted on
  @UserID, --Posted by
  GETDATE(), --Last Updated on
  @UserID --Last Updated by

  ---------------------------
  --Seed property for rent
  ---------------------------
  IF not exists (select top 1 name from Properties where Name='Birla House Demo')
  insert into Properties(SellRent,Name,PropertyTypeId,BHK,FurnishingTypeId,Price,BuiltArea,CarpetArea,Address,
  Address2,CityId,FloorNo,TotalFloors,ReadyToMove,MainEntrance,Security,Gated,Maintenance,EstPossessionOn,Age,Description,PostedOn,PostedBy,LastUpdatedOn,LastUpdatedBy)
  select 
  2, --Sell Rent
  'Birla House Demo', --Name
  (select Id from PropertyTypes where Name='Apartment'), --Property Type ID
  2, --BHK
  (select Id from FurnishingTypes where Name='Fully'), --Furnishing Type ID
  1800, --Price
  1400, --Built Area
  900, --Carpet Area
  '6 Street', --Address
  'Golf Course Road', -- Address2
  (select top 1 Id from Cities), -- City ID
  3, -- Floor No
  3, --Total Floors
  1, --Ready to Move
  'East', --Main Entrance
  0, --Security
  1, --Gated
  300, -- Maintenance
  '2019-01-01', -- Establishment or Posession on
  0, --Age
  'Well Maintained builder floor available for rent at prime location. # property features- - 5 mins away from metro station - Gated community - 24*7 security. # property includes- - Big rooms (Cross ventilation & proper sunlight) - 
  Drawing and dining area - Washrooms - Balcony - Modular kitchen - Near gym, market, temple and park - Easy commuting to major destination. Feel free to call With Query.', --Description
  GETDATE(), --Posted on
  @UserID, --Posted by
  GETDATE(), --Last Updated on
  @UserID --Last Updated by
   ");*/

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
                /*@"
            
             DECLARE @UserID as int
            SET @UserID = (select id from Users where Username='Demo')
            delete from Users where Username='Demo'
            delete from PropertyTypes where LastUpdatedBy=@UserID
             delete from FurnishingTypes where LastUpdatedBy=@UserID
             delete from Cities where LastUpdatedBy=@UserID
             delete from Properties where PostedBy=@UserId
             
        
            "); */
        }
    }
}
