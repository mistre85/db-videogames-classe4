--13- Selezionare le categorie dei videogame i quali hanno una media recensioni inferiore a 1.5 (10)
SELECT DISTINCT c.id AS category_id, c.name AS category_name
FROM videogames v
INNER JOIN reviews r ON v.id = r.videogame_id
INNER JOIN category_videogame cv ON v.id = cv.videogame_id
INNER JOIN categories c ON cv.category_id = c.id
GROUP BY v.id, c.id
having avg(cast(r.rating as decimal))< 1.5