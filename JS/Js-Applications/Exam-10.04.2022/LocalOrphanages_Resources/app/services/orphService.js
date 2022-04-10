import * as api from "./api.js";
import * as request from "./httpClient.js";

export const getAll = () => {
    return request.get(`${api.posts}?sortBy=_createdOn%20desc`);
}

export const create = (title,
  description,
  imageUrl,
  address,
  phone) => {
    return request.post(api.posts, { title,
      description,
      imageUrl,
      address,
      phone
     });
}

export const update = (title,
  description,
  imageUrl,
  address,
  phone,
  postId
) => {
  return request.put(`${api.posts}/${postId}`, { title,
    description,
    imageUrl,
    address,
    phone });
}

export const getOne = (postId) => {
  return request.get(`${api.posts}/${postId}`);
}

export const del = (postId) => {
  return request.del(`${api.posts}/${postId}`);
}

export const getOwn = (userId) => {
  return request.get(`${api.posts}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export const donate = (postId) => {
  return request.post(api.donations, { postId });
}

export const getAllDonations = (postId) => {
  return request.get(`${api.donations}?where=postId%3D%22${postId}%22&distinct=_ownerId&count`);
}

export const getDonationsFromUser = (postId, userId) => {
  return request.get(`${api.donations}?where=postId%3D%22${postId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

