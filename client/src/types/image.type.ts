export type ImageType = {
    id: number;
    itemType: number
    routeId: number;
    placeId: number;
    image: string;
    imageUrl?: string;
    isMain: boolean;
    createdByUserId: number;
    createdAt: Date;
}