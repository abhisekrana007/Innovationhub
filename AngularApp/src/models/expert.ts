export class Expert {

   expertId? : string
   username: string
   password: string
   email: string
   firstName: string
   lastName: string
   dateOfBirth: Date
   skills: string
   rating: number
   budget: number

  constructor(){
   this.expertId = ""
   this.username= ""
   this.password= ""
   this.email= ""
   this.firstName= ""
   this.lastName= ""
   this.dateOfBirth= new Date()
   this.skills= ""
   this.rating= 5
   this.budget= 500
  }
    
}