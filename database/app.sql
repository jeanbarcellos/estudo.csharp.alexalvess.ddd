CREATE TABLE "public"."user" (
    "id" serial4 NOT NULL,
    "name" varchar(128) NOT NULL,
    "birth_date" varchar(128) NOT NULL,
    "cpf" varchar(128) NOT NULL,
    CONSTRAINT "user_pkey" PRIMARY KEY ("id")
);

CREATE TABLE "public"."category" (
    "id" serial4 NOT NULL,
    "name" varchar(128) NOT NULL,
    CONSTRAINT "category_pkey" PRIMARY KEY ("id")
);