using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PetProject.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UserFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledEvent_Events_EventsEventId",
                table: "ScheduledEvent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduledEvent",
                table: "ScheduledEvent");

            migrationBuilder.RenameTable(
                name: "ScheduledEvent",
                newName: "ScheduledEvents");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduledEvent_EventsEventId",
                table: "ScheduledEvents",
                newName: "IX_ScheduledEvents_EventsEventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduledEvents",
                table: "ScheduledEvents",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledEvents_Events_EventsEventId",
                table: "ScheduledEvents",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduledEvents_Events_EventsEventId",
                table: "ScheduledEvents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ScheduledEvents",
                table: "ScheduledEvents");

            migrationBuilder.RenameTable(
                name: "ScheduledEvents",
                newName: "ScheduledEvent");

            migrationBuilder.RenameIndex(
                name: "IX_ScheduledEvents_EventsEventId",
                table: "ScheduledEvent",
                newName: "IX_ScheduledEvent_EventsEventId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ScheduledEvent",
                table: "ScheduledEvent",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduledEvent_Events_EventsEventId",
                table: "ScheduledEvent",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId");
        }
    }
}
