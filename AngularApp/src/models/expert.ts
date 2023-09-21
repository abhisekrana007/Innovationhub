export class Expert {
    constructor(
      public username: string,
      public password: string,
      public email: string,
      public firstName: string,
      public lastName: string,
      public dateOfBirth: string,
      public skills: string,
      public rating: number,
      public budget: number
    ) {}
  }