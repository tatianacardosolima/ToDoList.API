CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "List" (
    "Id" uuid NOT NULL,
    "Name" character varying(120) NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "ModifiedAt" timestamp with time zone,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_List" PRIMARY KEY ("Id")
);

CREATE TABLE "Task" (
    "Id" uuid NOT NULL,
    "ListId" uuid NOT NULL,
    "Title" character varying(120) NOT NULL,
    "Description" character varying(500),
    "URL" character varying(2083),
    "StartAt" timestamp with time zone,
    "EndAt" timestamp with time zone,
    "Status" integer NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "ModifiedAt" timestamp with time zone,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_Task" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Task_List_ListId" FOREIGN KEY ("ListId") REFERENCES "List" ("Id") ON DELETE CASCADE
);

CREATE TABLE "Checklist" (
    "Id" uuid NOT NULL,
    "TaskId" uuid NOT NULL,
    "Item" character varying(180) NOT NULL,
    "Check" boolean NOT NULL,
    "CreatedAt" timestamp with time zone NOT NULL,
    "ModifiedAt" timestamp with time zone,
    "Active" boolean NOT NULL,
    CONSTRAINT "PK_Checklist" PRIMARY KEY ("Id"),
    CONSTRAINT "FK_Checklist_Task_TaskId" FOREIGN KEY ("TaskId") REFERENCES "Task" ("Id") ON DELETE CASCADE
);

CREATE INDEX "IX_Checklist_TaskId" ON "Checklist" ("TaskId");

CREATE INDEX "IX_Task_ListId" ON "Task" ("ListId");

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240711185836_Initial-Migration', '8.0.7');

COMMIT;

