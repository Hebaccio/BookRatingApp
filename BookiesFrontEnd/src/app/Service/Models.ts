export class SocialMedia {
  id!: number;
  socialMediaName!: string;
  picture!: string;
}

export class Genre {
  genreID!: number;
  genreName!: string;
  genreDescription!: string;
}

export class Tag {
  tagID!: number;
  tagName!: string;
  tagDescription!: string;
}

export class Role {
  roleID!: number;
  roleName!: string;
  order!: number;
}

export class Relation {
  relationID!: number;
  relationName!: string;
  relationOrder!: number;
}
