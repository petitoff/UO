package pl.opole.uni.lista3.services;

import org.springframework.data.jpa.repository.JpaRepository;

import java.util.List;

public class GenericService<T, ID> {
    private final JpaRepository<T, ID> repository;

    public GenericService(JpaRepository<T, ID> repository) {
        this.repository = repository;
    }

    public List<T> getAll() {
        return repository.findAll();
    }

    public T getById(ID id) {
        return repository.findById(id).orElse(null);
    }

    public T add(T entity) {
        return repository.save(entity);
    }

    public T update(ID id, T entity) {
        if (repository.existsById(id)) {
            return repository.save(entity);
        }
        return null;
    }

    public void delete(ID id) {
        repository.deleteById(id);
    }
}
