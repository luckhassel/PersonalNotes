export interface CreateUpdateNote{
    startDate: Date,
    endDate: Date,
    subject: string,
    description: string
}

export interface Note extends CreateUpdateNote{
    id: string,
    userId: string
}