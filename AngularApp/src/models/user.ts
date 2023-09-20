import { EmailValidator } from "@angular/forms";

export class User
{
    Email : string;
    Password : string;

    constructor() {
        this.Email = "",
        this.Password = ""
    }
}
