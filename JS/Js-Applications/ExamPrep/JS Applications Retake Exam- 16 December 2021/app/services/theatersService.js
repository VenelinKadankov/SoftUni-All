import * as api from "./api.js";
import * as request from "./httpClient.js";

export const getAll = () => {
    return request.get(`${api.theaters}?sortBy=_createdOn%20desc&distinct=title`);
}

export const create = (title,
  date,
  author,
  imageUrl,
  description
) => {
    return request.post(api.theaters, { title,
      date,
      author,
      imageUrl,
      description
     });
}

export const update = (title,
  date,
  author,
  imageUrl,
  description,
  theaterId
) => {
  return request.put(`${api.theaters}/${theaterId}`, { title,
    date,
    author,
    imageUrl,
    description });
}

export const getOne = (id) => {
  return request.get(`${api.theaters}/${id}`);
}

export const del = (theaterId) => {
  return request.del(`${api.theaters}/${theaterId}`);
}

export const getOwn = (userId) => {
  return request.get(`${api.theaters}?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export const like = (theaterId) => {
  return request.post(api.likes, { theaterId });
}

export const getAllLikes = (theaterId) => {
  return request.get(`${api.likes}?where=theaterId%3D%22${theaterId}%22&distinct=_ownerId&count`);
}

export const getLikesFromUser = (theaterId, userId) => {
  return request.get(`${api.likes}?where=theaterId%3D%22${theaterId}%22%20and%20_ownerId%3D%22${userId}%22&count`);
}

