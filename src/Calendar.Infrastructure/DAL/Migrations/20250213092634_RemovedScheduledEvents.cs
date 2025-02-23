using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Calendar.Infrastructure.DAL.Migrations
{
    /// <inheritdoc />
    public partial class RemovedScheduledEvents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduledEvents");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ScheduledEvents",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uuid", nullable: false),
                    CanOverlap = table.Column<bool>(type: "boolean", nullable: false),
                    EventDescription = table.Column<string>(type: "text", nullable: false),
                    EventName = table.Column<string>(type: "text", nullable: false),
                    EventsEventId = table.Column<Guid>(type: "uuid", nullable: true),
                    From = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    To = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledEvents", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_ScheduledEvents_Events_EventsEventId",
                        column: x => x.EventsEventId,
                        principalTable: "Events",
                        principalColumn: "EventId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledEvents_EventsEventId",
                table: "ScheduledEvents",
                column: "EventsEventId");
        }
    }
}
