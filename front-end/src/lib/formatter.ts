const prependZero = (value: number): string => value < 10 ? `0${value}` : `${value}`;
export const dateFormatter = (date: Date): string =>
    `${date.getFullYear()}-${prependZero(date.getMonth() + 1)}-${prependZero(date.getDate())}`

export const priceFormatter = (price: number, currency: string): string => {
    let formattedPrice: string = (((+price || 0) * 100) / 100).toLocaleString('en-US');
    formattedPrice = formattedPrice.includes('.') ? `${formattedPrice}00` : `${formattedPrice}.00`;
    return `${formattedPrice.slice(0, formattedPrice.indexOf('.') + 3).replaceAll(',', ' ').replaceAll('.', ',')} ${currency}`;
}